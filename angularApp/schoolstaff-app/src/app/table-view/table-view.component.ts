import { Component, OnInit} from '@angular/core';
import { ApiConnectorsService } from '../api-connectors.service';
import { CollectStaffDataService } from '../collect-staff-data.service';

import {  Staff } from '../staff';

@Component({
  selector: 'app-table-view',
  templateUrl: './table-view.component.html',
  styleUrls: ['./table-view.component.css']
})
export class TableViewComponent implements OnInit {

  staffType : number ;

  json :JSON;

  lstStaff : Staff[];

  headers = [];

  constructor(
    private apiConnector : ApiConnectorsService,
    private collectStaffData : CollectStaffDataService,
  ) { }

 

  ngOnInit():void{
    this.staffType = 1;
    this.setHeaders();
    this.getStaff();
    
  }

  ChangeStaffType(staffType : number){
    this.staffType = staffType;
    this.setHeaders();
    this.getStaff();
    
  }

  
  getStaff(){

    this.apiConnector.getStaff(this.staffType)
      .subscribe((data )=>{
        // debugger;
        this.lstStaff = data;});
    
  }

  setHeaders(){
    this.headers = ['Name','Address','Phonenumber','Salary'];
    switch(this.staffType){
      case 1:
        this.headers.push('Subject','Class');
        break;
        
      case 2:
      case 3:
        this.headers.push('Post');
        break;
    }
  }

 

  collectData(staff : Staff){
    this.collectStaffData.collectData(staff);
  }

  ToggleDeletePopup(){
    event.stopPropagation();
    var popup = document.getElementById("delConfirm");
    popup.classList.toggle("show");
    // this.apiConnector.deleteStaff(staffId).subscribe(()=>{this.getStaff()});
    
  }

  DeleteStaff(staffId : number){
    this.apiConnector.deleteStaff(staffId).subscribe(()=>{this.getStaff()});
    this.ToggleDeletePopup();
  }

  

    
    

}
