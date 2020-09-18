import { Injectable } from '@angular/core';
import { StaffForm , Staff} from './staff';

@Injectable({
  providedIn: 'root'
})
export class CollectStaffDataService {

  constructor() { }

  staff = new StaffForm();

  collectData(staff : Staff){
    this.staff.StaffId = staff.StaffId;
    this.staff.Name = staff.Name;
    this.staff.HouseName = staff.Address.HouseName;
    this.staff.City = staff.Address.City;
    this.staff.State = staff.Address.State;
    this.staff.Pin = staff.Address.Pin;
    this.staff.PhoneNumber = staff.PhoneNumber;
    this.staff.Salary = staff.Salary;
    this.staff.Post = staff.Post;
    this.staff.Subject = staff.Subject;
    this.staff.AssignedClass = staff.AssignedClass;
  }

  getData(){
    return this.staff;
  }
}
