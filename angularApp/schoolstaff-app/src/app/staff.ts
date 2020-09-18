export interface Staff{
    StaffId:number;
    Name:string;
    Address:{
        HouseName:string;
        City:string;
        State:string;
        Pin:number;
    }
    Salary:number;
    PhoneNumber:number;
    Subject:string;
    AssignedClass:string;
    Post :string;
    StaffType:number;
}

export class StaffForm{
    StaffId:number;
    Name:string;
    HouseName:string;
    City:string;
    State:string;
    Pin:number;
    Salary:number;
    PhoneNumber:number;
    Subject:string;
    AssignedClass:string;
    Post :string;
    StaffType:number;
    
}