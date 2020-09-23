import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SupportStaffComponent } from './support-staff/support-staff.component';
import {SharedModule} from '../shared/shared.module';
import { AppRoutingModule } from '../../app-routing.module';



@NgModule({
  declarations: [SupportStaffComponent],
  imports: [
    CommonModule,
    SharedModule,
    AppRoutingModule
  ],
  exports:[
    SupportStaffComponent
  ]
})
export class SupportStaffModule { }
