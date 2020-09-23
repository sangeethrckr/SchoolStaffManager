import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TeachingStaffComponent } from './teaching-staff/teaching-staff.component';
import {SharedModule} from '../shared/shared.module';
import { AppRoutingModule } from '../../app-routing.module';



@NgModule({
  declarations: [TeachingStaffComponent],
  imports: [
    CommonModule,
    SharedModule,
    AppRoutingModule,
  ],
  exports: [
    TeachingStaffComponent,
  ]
})
export class TeachingStaffModule { }
