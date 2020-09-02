import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { CitaProducto } from '../_models/cita-producto';
import { FormGroup, FormControl, Validators, FormArray } from '@angular/forms';
import { ProductoService } from '../_services/producto.service';
import { Producto } from '../_models/producto';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { FinalizarNuevoProductoComponent } from '../_components/finalizar-nuevo-producto/finalizar-nuevo-producto.component';


@Component({
  selector: 'app-finalizar-cita-productos',
  templateUrl: './finalizar-cita-productos.component.html',
  styleUrls: ['./finalizar-cita-productos.component.css']
})
export class FinalizarCitaProductosComponent implements OnInit {

  @Input()
  cita: CitaProducto;

  
  productos: Producto[]; // ese array es para poder comprar nuevos productos ( se mostrara en el select)
  productosCita: Producto[]; // este array es el que se envia al componente padre para que la cita sea finalizada
  productosCitaTabla = new MatTableDataSource<Producto>(); // Es para mostrar los producos que pertenecen a la cita 

  columnas: string[] = ['producto', 'cantidad', 'editar', 'eliminar'];

  constructor(  private productoService: ProductoService, public dialog: MatDialog, ) { }

  ngOnInit(): void {
    this.productosCitaTabla.data = this.cita.productos;
    this.productosCita = this.cita.productos;
    this.cargarProductos();

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.productosCitaTabla.filter = filterValue.trim().toLowerCase();
  }

  cargarProductos(): void {
    this.productoService.getProducto().subscribe({
      next: res => {
        this.productos = res;
       
      },
      error: err => {
        console.log(err);
      }
    });
  }

  editar(producto: Producto): void {

    const dialogRef = this.dialog.open(FinalizarNuevoProductoComponent, {
      width: '350px',
      height: '300px',
      data: {tipo: 'editar', productos: this.productos, producto: producto}
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      this.cita.productos = this.cita.productos.map( p => {
        if( p.id === dialogResult.id ){
          return dialogResult;
        }
        return p;
      });
    });

  }

  eliminar(producto: Producto): void {
    
    this.productosCita = this.productosCita.map( p => {
      if ( p.id === producto.id){
        p.cantidad = 0;
      }
      return p;
    });
   
  }

  agregarProducto(): void {
    var noDeseados = this.cita.productos.map( cp => cp.id);
    var prod: Producto[] = this.productos.filter(p => p.idComercio === this.cita.idComercio);
    prod = prod.filter( p => noDeseados.indexOf(p.id) === -1);

  
    const dialogRef = this.dialog.open(FinalizarNuevoProductoComponent, {
      width: '350px',
      height: '300px',
      data: {tipo: 'crear', productos: prod, producto: null}
    });

    dialogRef.afterClosed().subscribe(dialogResult => {
      this.cita.productos.push(dialogResult);
      this.productosCitaTabla.data = this.cita.productos;
     
    });


  }

}
