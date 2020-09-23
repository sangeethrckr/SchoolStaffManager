import { Component, OnChanges, Input } from '@angular/core';

import { Staff } from '../../../models/staff'

import { ApiConnectorsService } from '../../../services/api-connectors.service';
import { CollectStaffDataService } from '../../../services/collect-staff-data.service';

@Component({
  selector: 'app-form',
  templateUrl: './form.component.html',
  styleUrls: ['./form.component.css']
})
export class FormComponent implements OnChanges {

  staff  = new Staff();
  
  jsonString : JSON;
  @Input() staffType : number;

  @Input() task : number;

  constructor(
    // private location: Location,
    // private route: ActivatedRoute,
    private apiConnector : ApiConnectorsService,
    private collectStaffData : CollectStaffDataService,
  ) { }

  ngOnInit(): void {
    // this.staff = this.collectStaffData.getData();
  }

  ngOnChanges():void{
    if(this.task==2){
      this.staff = this.collectStaffData.getData();
    }
  }

  goBack(): void {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
    window.location.reload();
  }

  

  onSubmit(){
    if(this.task==1){

      if(this.staffType == 1){
        this.jsonString = this.JsonStringifyCreateTeacher(this.staff.Subject,this.staff.AssignedClass,this.staff.Name,this.staff.Address.HouseName,this.staff.Address.City,this.staff.Address.State,+this.staff.Address.Pin,this.staff.PhoneNumber,+this.staff.Salary);
      // console.log(JSON.stringify(this.jsonString));
      }
      else{
        this.jsonString = this.JsonStringifyCreateAdminSupport(this.staff.Post,this.staff.Name,this.staff.Address.HouseName,this.staff.Address.City,this.staff.Address.State,+this.staff.Address.Pin,this.staff.PhoneNumber,+this.staff.Salary,this.staffType-1);

      }
      this.apiConnector.createStaff(this.jsonString)
          .subscribe(()=>{ this.goBack() });

    }

    else{
      if(this.staffType == 1){
        this.jsonString = this.JsonStringifyUpdate(this.staff.Name,this.staff.Address.HouseName,this.staff.Address.City,this.staff.Address.State,this.staff.Address.Pin,this.staff.PhoneNumber,this.staff.Salary,this.staff.AssignedClass);
      }
      else{
        this.jsonString = this.JsonStringifyUpdate(this.staff.Name,this.staff.Address.HouseName,this.staff.Address.City,this.staff.Address.State,this.staff.Address.Pin,this.staff.PhoneNumber,this.staff.Salary,this.staff.Post);
      }
      
      //console.log("update staff" + this.staff.StaffId);
      this.apiConnector.updateStaff(this.staff.StaffId,this.jsonString)
          .subscribe(()=>{ this.goBack() });
      
    }
    

  }

  JsonStringifyCreateTeacher(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary){
    var result = JSON.stringify(
        {
            Subject: subject,
            AssignedClass: classAssigned,
            
            Name: name,
            Address: {
                HouseName: houseName,
                City: city,
                State: state,
                Pin: pin
            },
            PhoneNumber: phoneNumber,
            Salary: salary,
            StaffType: 0
        }

        );

    var json = JSON.parse(result);

    return json;

  }

  JsonStringifyCreateAdminSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType){
    var result = JSON.stringify(
        {
            Post: post,
            
            Name: name,
            Address: {
                HouseName: houseName,
                City: city,
                State: state,
                Pin: pin
            },
            PhoneNumber: phoneNumber,
            Salary: salary,
            StaffType: staffType
        }
        );

        var json = JSON.parse(result);

        return json;
  }

  JsonStringifyUpdate(name,houseName,city,state,pin,phoneNumber,salary,specificData){
    var result = JSON.stringify(
        {
        Name:name,
        Address:{
            HouseName:houseName,
            City:city,
            State:state,
            Pin:pin
        },
        PhoneNumber:phoneNumber,
        Salary:salary,
        SpecificData:specificData
        }
        );

      var json = JSON.parse(result);

      return json;

}

}
