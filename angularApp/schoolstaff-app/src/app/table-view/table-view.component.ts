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

  selectedStaff = [];

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

  // DeleteMultiple(){
  //   for(var i = 0;i<this.selectedStaff.length;i++){
  //     //console.log(this.selectedStaff[i]);
  //     this.apiConnector.deleteStaff(this.selectedStaff[i]).subscribe(()=>{this.getStaff()});
  //   }
  //   //this.getStaff();
  //   this.ToggleMultipleDeletePopUp();
  // }

  DeleteMultiple(){
    this.apiConnector.deleteMultipleStaff(this.selectedStaff).subscribe(()=>{this.getStaff()});
      
      //this.getStaff();
      this.ToggleMultipleDeletePopUp();
  }



  ChangeStaffType(staffType : number){
    this.staffType = staffType;
    this.setHeaders();
    this.getStaff();

    switch(staffType){
      case 1:
        document.getElementById("TnavButton").className = "navButton   active";
        document.getElementById("AnavButton").className = "navButton";
        document.getElementById("SnavButton").className = "navButton";
        break;
      case 2:
        document.getElementById("TnavButton").className = "navButton";
        document.getElementById("AnavButton").className = "navButton   active";
        document.getElementById("SnavButton").className = "navButton";
        break;
        break;
      case 3:
        document.getElementById("TnavButton").className = "navButton";
        document.getElementById("AnavButton").className = "navButton";
        document.getElementById("SnavButton").className = "navButton   active";
        break;
        break;
    }
    
    
  }

    
    

}
