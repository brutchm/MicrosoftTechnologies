
export interface Usuario {
	id: string;
	nombre: string;
	apellidoUno: string;
	apellidoDos: string;
	genero: string;
	fechaNacimiento: Date;
	correoElectronico: string;
	numeroTelefono: string;
	idDireccion: number;
	estado: string;
	codigo: string;
	tipo: string;
}

export class UsuarioCliente {
  id: string;
  nombre: string;
  apellidoUno: string;
  apellidoDos: string;
  genero: string;
  fechaNacimiento: Date;
  correoElectronico: string;
  numeroTelefono: string;
  idDireccion: number;
  estado: string;
  codigo: string;
  tipo: string;
}
