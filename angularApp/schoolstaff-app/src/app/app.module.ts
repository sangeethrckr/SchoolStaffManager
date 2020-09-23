import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'; 
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// import { TopBarComponent } from './top-bar/top-bar.component';

import { TeachingStaffModule } from './components/teaching-staff/teaching-staff.module';
import { AdminStaffModule} from './components/admin-staff/admin-staff.module';
import { SupportStaffModule} from './components/support-staff/support-staff.module'

// import { TableViewComponent } from './components/table-view/table-view.component';
// import { FormComponent } from './components/form/form.component';

// import { CollectStaffDataService } from './services/collect-staff-data.service';
// import {HelpersService } from './services/helpers.service'



@NgModule({
  declarations: [
    AppComponent,
    // TopBarComponent,
    // TableViewComponent,
    // FormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    TeachingStaffModule,
    AdminStaffModule,
    SupportStaffModule,
  ],
  // exports:[FormComponent],
  // providers: [CollectStaffDataService, HelpersService],
  bootstrap: [AppComponent]
})
export class AppModule { }
