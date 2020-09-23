import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminStaffComponent } from './admin-staff/admin-staff.component';
import { AppRoutingModule } from '../../app-routing.module';
import {SharedModule} from '../shared/shared.module';



@NgModule({
  declarations: [AdminStaffComponent],
  imports: [
    CommonModule,
    AppRoutingModule,
    SharedModule
  ],
  exports:[
    AdminStaffComponent
  ]
})
export class AdminStaffModule { }
