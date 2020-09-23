import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

// import { FormComponent } from './form/form.component'
import { TeachingStaffComponent } from './components/teaching-staff/teaching-staff/teaching-staff.component'
import { AdminStaffComponent } from './components/admin-staff/admin-staff/admin-staff.component';
import { SupportStaffComponent } from './components/support-staff/support-staff/support-staff.component'

const routes: Routes = [
  { path: '', redirectTo: '/teaching', pathMatch: 'full' },
  {path :'teaching', component: TeachingStaffComponent},
  {path :'admin', component: AdminStaffComponent},
  {path :'support', component: SupportStaffComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
