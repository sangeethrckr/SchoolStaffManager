import { Component, OnInit } from '@angular/core';

import { ApiConnectorsService } from '../../../services/api-connectors.service';
import { CollectStaffDataService } from '../../../services/collect-staff-data.service';

import {  Staff } from '../../../models/staff';

@Component({
  selector: 'app-support-staff',
  templateUrl: './support-staff.component.html',
  styleUrls: ['./support-staff.component.css']
})
export class SupportStaffComponent implements OnInit {

  staffType : number ;

  json :JSON;

  lstStaff : Staff[];

  selectedStaff = [];

  headers = ['Name','Address','Phonenumber','Salary','Post'];

  task : number;

  constructor(
    private apiConnector : ApiConnectorsService,
    private collectStaffData : CollectStaffDataService,
  ) { }

 

  ngOnInit():void{
    this.staffType = 3;
    // // this.setHeaders();
    this.getStaff();
    
  }

  
  getStaff(){

    this.apiConnector.getStaff(this.staffType)
      .subscribe((data )=>{
        // debugger;
        this.lstStaff = data;});
    
  }

  // setHeaders(){
  //   this.headers = ['Name','Address','Phonenumber','Salary'];
  //   switch(this.staffType){
  //     case 1:
  //       this.headers.push('Subject','Class');
  //       break;
        
  //     case 2:
  //     case 3:
  //       this.headers.push('Post');
  //       break;
  //   }
  // }

 

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

  clickCheckBox(){
    event.stopPropagation();
  }
  
  checkRow(e,staffId : number){
      if(e.target.checked){
        this.selectedStaff.push(staffId);
        //console.log(this.selectedStaff);
      }
      else{
        const index = this.selectedStaff.indexOf(staffId, 0);
        if (index > -1) {
          this.selectedStaff.splice(index, 1);
          //console.log(this.selectedStaff);
        }

      }

  }

  ToggleMultipleDeletePopUp(){
    var popup = document.getElementById("multipleDelConfirm");
    popup.classList.toggle("show");
    console.log(this.selectedStaff);
  }

  ToggleFormPopUp(task){
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
    this.task = task;
  }

  

  DeleteMultiple(){
    this.apiConnector.deleteMultipleStaff(this.selectedStaff).subscribe(()=>{this.getStaff()});
      
      //this.getStaff();
      this.ToggleMultipleDeletePopUp();
  }


}
