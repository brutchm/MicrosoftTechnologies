import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EmpleadoService } from '../../../_services/empleado.service';
import { FormEmpleadoComponent } from '../../components/form-empleado/form-empleado.component';
import { SucursalService } from '../../../_services/sucursal.service';
import { Sucursal } from '../../../_models/sucursal';
import { ComercioService } from '../../../_services/comercio.service';


@Component({
  selector: 'app-empleado-comercio',
  templateUrl: './empleado-comercio.component.html',
  styleUrls: ['./empleado-comercio.component.css']
})
export class EmpleadoComercioComponent implements OnInit {

  actualizarDatos = false;
  sucursales: Sucursal[];
  idComercio: string;
  idSucursal: string;

  constructor( 
    public dialog: MatDialog, 
    private empleadoService: EmpleadoService, 
    private sucursalService: SucursalService, 
    private comercioService: ComercioService ) { 
     
      const user = JSON.parse(localStorage.getItem('user'));
      if(user.tipo === 'C'){
        this.idComercio = user.comercio.cedJuridica;
      } else {
        this.idComercio = user.empleado.idComercio;
      }
     
      this.cargarSucursales();
    }

  ngOnInit(): void {
  }


  selecionSucursal(sucursal): void {
    this.idSucursal = sucursal;
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(FormEmpleadoComponent, {
      width: '750px',
      height: '400px',
      data: { idComercio: this.idComercio, idSucursal: this.idSucursal }
    });

    dialogRef.afterClosed().subscribe( result => {
      this.actualizarDatos = !this.actualizarDatos;
    });
  }

  cargarSucursales(): void {
    this.sucursalService.get().subscribe({
      next: res => {
        this.sucursales = res.filter( s => s.idComercio === this.idComercio);
      },
      error: err => console.log(err)
    });
  }


}
