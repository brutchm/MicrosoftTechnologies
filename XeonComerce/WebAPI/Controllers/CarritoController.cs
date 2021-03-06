﻿using AppCore;
using Entities;
using Management;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarritoController : ControllerBase
    {
        private CarritoManagement am = new CarritoManagement();

        [HttpGet("{ced}")]
        public List<Carrito> RetriveAll(string ced)
        {
            return am.RetriveAll(new Carrito { IdUsuario=ced });
        }

        [HttpGet("{ced}/{id}")]
        public Carrito RetriveById(string ced, int id)
        {
            return am.RetriveById(new Carrito { IdUsuario=ced, IdProducto = id});
        }

        [HttpPost]
        public IActionResult Create (Carrito a)
        {
            try
            {
                if (a.Cantidad <= 0) throw new Exception("La cantidad no puede ser menor a 1");
                List<Carrito> lst = am.RetriveAll(a);
                ProductoServicioManagement pm = new ProductoServicioManagement();
                Producto p2 = pm.RetrieveByIdProducto(new Producto { Id = a.IdProducto });
                var b = lst.Find((i)=>i.IdUsuario == a.IdUsuario);

                if (p2 != null) { 
                    if (a.Cantidad > p2.Cantidad) throw new Exception("No existen tantas unidades de dicho producto");
                }
                else
                    throw new Exception("No existe dicho producto");

                if (b != null)
                {
                    Producto p1 = pm.RetrieveByIdProducto(new Producto { Id = b.IdProducto });
                    if (p1 != null && p2 != null)
                    {
                        if (p1.IdComercio != p2.IdComercio) throw new Exception("¡No se puede agregar productos de diferentes comercios al mismo tiempo!");
                    }
                }
                var c = lst.Find((i) => i.IdProducto == a.IdProducto);
                if (c != null) throw new Exception("Ya existe dicho producto en el carrito");
                am.Create(a);
                return Ok(new { msg = "Se agregó el producto al carrito" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { msg=e.Message });
            }
        }

        [HttpPut]
        public IActionResult Update(Carrito a)
        {
            try
            {
                if (a.Cantidad <= 0) throw new Exception("La cantidad no puede ser menor a 1");
                ProductoServicioManagement pm = new ProductoServicioManagement();
                Producto p2 = pm.RetrieveByIdProducto(new Producto { Id = a.IdProducto });
                if (p2 != null)
                {
                    if (a.Cantidad > p2.Cantidad) throw new Exception("No existen tantas unidades de dicho producto");
                }
                else
                {
                    throw new Exception("No existe dicho producto");
                }
                am.Update(a);
                return Ok(new { msg = "Se actualizó el producto al carrito" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { msg = e.Message });
            }
        }

        [HttpDelete]
        public IActionResult Delete(Carrito car)
        {
            try
            {
                am.Delete(car);
                return Ok(new { msg = "Se eliminó el producto al carrito" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { msg = e.Message });
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteAll(string id)
        {
            try
            {
                am.DeleteAll(new Carrito { IdUsuario=id});
                return Ok(new { msg = "Se limpió el carrito" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { msg = e.Message });
            }
        }


        [HttpPost("xml/{cedula}")]
        public IActionResult Xml(PdfXml pdfXml, string cedula)
        {
            try
            {
                UsuarioManagement uC = new UsuarioManagement();
                Usuario u = uC.RetrieveById(new Usuario { Id=cedula });
                if (u != null)
                {
                    Execute(u, pdfXml).Wait();
                    return Ok(new { msg = "Se envío al correo la factura"});
                }
                else
                {
                    throw new Exception("Usuario no se encontró");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg = ex.Message });
            }
        }



        private static async Task Execute(Usuario user, PdfXml pdfXml)
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(pdfXml.XML);
            byte[] bytes = Encoding.Default.GetBytes(xdoc.OuterXml);
            HtmlToPdf oHtmlToPdf = new HtmlToPdf();
            PdfDocument oPdfDocument = oHtmlToPdf.ConvertHtmlString(pdfXml.Html);
            byte[] pdf = oPdfDocument.Save();
            oPdfDocument.Close();

            var apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("brutchm@ucenfotec.ac.cr", "GetItSafely");
            var subject = "Factura de compra en GetItSafely";
            var to = new EmailAddress(user.CorreoElectronico.ToString(), user.Nombre.ToString());
            var plainTextContent = ("El resumen de su compra más reciente: ");
            var htmlContent = "<strong>El resumen de su compra más reciente: </strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            msg.AddAttachment("factura.xml", Convert.ToBase64String(bytes));
            msg.AddAttachment("factura.pdf", Convert.ToBase64String(pdf));
            var response = await client.SendEmailAsync(msg);
        }





    }
}
