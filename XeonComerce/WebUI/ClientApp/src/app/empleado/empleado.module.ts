import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListEmpleadosComponent } from './components/list-empleados/list-empleados.component';
import { FormEmpleadoComponent } from './components/form-empleado/form-empleado.component';
import { EmpleadoAdminComponent } from './pages/empleado-admin/empleado-admin.component';
import { MatTableModule } from '@angular/material/table';
import { EmpleadoRoutingModule } from './empleado-routing.module';
import { MatPaginatorModule } from '@angular/material/paginator';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDialogModule } from '@angular/material/dialog';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatTabsModule} from '@angular/material/tabs';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import { EmpleadoHorarioComponent } from './pages/empleado-horario/empleado-horario.component';
import { ListHorarioComponent } from './components/list-horario/list-horario.component';
import {MatSelectModule} from '@angular/material/select';
import { FormHorarioComponent } from './components/form-horario/form-horario.component';
import { PerfilEmpleadoComponent } from './components/perfil-empleado/perfil-empleado.component';
import {MatCardModule} from '@angular/material/card';
import { CalendarioEmpleadoComponent } from './components/calendario-empleado/calendario-empleado.component';


import { ScheduleModule, RecurrenceEditorModule, DayService, WeekService, WorkWeekService, MonthService, MonthAgendaService } from '@syncfusion/ej2-angular-schedule';
import { EmpleadoComercioComponent } from './pages/empleado-comercio/empleado-comercio.component';

@NgModule({
  declarations: [
    ListEmpleadosComponent,
    FormEmpleadoComponent,
    EmpleadoAdminComponent,
    EmpleadoHorarioComponent,
    ListHorarioComponent,
    FormHorarioComponent,
    PerfilEmpleadoComponent,
    CalendarioEmpleadoComponent,
    EmpleadoComercioComponent,
  ],
  imports: [
    CommonModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatButtonModule,
    MatIconModule,
    MatInputModule,
    EmpleadoRoutingModule,
    FlexLayoutModule,
    MatDialogModule,
    MatTabsModule,
    MatSnackBarModule,
    MatSelectModule,
    MatCardModule,
    FormsModule,
    ReactiveFormsModule, 
    ScheduleModule,
    RecurrenceEditorModule
  ],
  providers: [  DayService, WeekService, WorkWeekService, MonthService, MonthAgendaService ],
})
export class EmpleadoModule { }
