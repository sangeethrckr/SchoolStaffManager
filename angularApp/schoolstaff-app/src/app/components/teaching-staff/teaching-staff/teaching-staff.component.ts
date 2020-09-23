import { Component, OnInit } from '@angular/core';

import { ApiConnectorsService } from '../../../services/api-connectors.service';
import { CollectStaffDataService } from '../../../services/collect-staff-data.service';

import {  Staff } from '../../../models/staff';

@Component({
  selector: 'app-teaching-staff',
  templateUrl: './teaching-staff.component.html',
  styleUrls: ['./teaching-staff.component.css']
})
export class TeachingStaffComponent implements OnInit {

  staffType : number ;

  // json :JSON;

  lstStaff : Staff[];

  selectedStaff = [];

  headers = ['Name','Address','Phonenumber','Salary','Subject','Class'];

  task : number;

  showForm : boolean = false;
  showDeleteConfirmation : boolean =false;
  showMultipleDeleteConfirmation : boolean =false;

  constructor(
    private apiConnector : ApiConnectorsService,
    private collectStaffData : CollectStaffDataService,
  ) { }

 

  ngOnInit():void{
    this.staffType = 1;
    // // this.setHeaders();
    this.getStaff();
    
  }

  
  getStaff(){

    this.apiConnector.getStaff(this.staffType)
      .subscribe((data )=>{
        // debugger;
        this.lstStaff = data;});
    
  }

 

 

  // collectData(staff : Staff){
  //   this.collectStaffData.collectData(staff);
  // }

  ToggleFormPopUp(task){
    this.showForm = !this.showForm;
    this.task = task;
  }

  ToggleDeletePopup(){
    event.stopPropagation();
    this.showDeleteConfirmation = !this.showDeleteConfirmation;
    
  }

  ToggleMultipleDeletePopUp(){
    this.showMultipleDeleteConfirmation = !this.showMultipleDeleteConfirmation;
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

 



  

  DeleteMultiple(){
    this.apiConnector.deleteMultipleStaff(this.selectedStaff).subscribe(()=>{this.getStaff()});
      
      //this.getStaff();
      this.ToggleMultipleDeletePopUp();
  }



  // ChangeStaffType(staffType : number){
  //   this.staffType = staffType;
  //   this.setHeaders();
  //   this.getStaff();

  //   switch(staffType){
  //     case 1:
  //       document.getElementById("TnavButton").className = "navButton   active";
  //       document.getElementById("AnavButton").className = "navButton";
  //       document.getElementById("SnavButton").className = "navButton";
  //       break;
  //     case 2:
  //       document.getElementById("TnavButton").className = "navButton";
  //       document.getElementById("AnavButton").className = "navButton   active";
  //       document.getElementById("SnavButton").className = "navButton";
  //       break;
  //       break;
  //     case 3:
  //       document.getElementById("TnavButton").className = "navButton";
  //       document.getElementById("AnavButton").className = "navButton";
  //       document.getElementById("SnavButton").className = "navButton   active";
  //       break;
  //       break;
  //   }
    
    
  // }

    
    

}



