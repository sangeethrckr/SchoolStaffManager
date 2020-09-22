function FormAction(staffType,task,staffId){
    var name = document.getElementById("name").value;
    var houseName = document.getElementById("houseName").value;
    var city = document.getElementById("city").value;
    var state = document.getElementById("state").value;
    var pin = parseInt(document.getElementById("pin").value);
    var phoneNumber = document.getElementById("phoneNumber").value;
    var salary = parseFloat(document.getElementById("salary").value);
    
    
    if(staffType == 0){

        var subject = document.getElementById("post-subject").value;
        var classAssigned = document.getElementById("classAssigned2").value;
    
        if(task == 1){
            postBody = JsonStringifyCreateTeacher(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary);
            CreateStaff(postBody)
            .then(() =>{
                ToggleFormPopup(0);
                ShowStaffPage(staffType);
            });
            
        }
        else{
            var putBody = JsonStringifyUpdate(name,houseName,city,state,pin,phoneNumber,salary,classAssigned);
            UpdateStaff(staffId,putBody)
            .then(()=>{
                ToggleFormPopup(0);
                ToggleConfirmPopUp();
                ShowStaffPage(staffType);
            });
            
        
        }
    

    }
    else{
        var post = document.getElementById("post-subject").value;
        if(task == 1){
            var postBody = JsonStringifyCreateAdminSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType);
            CreateStaff(postBody)
            .then(() =>{
                ToggleFormPopup(1);
                ShowStaffPage(staffType);
            });
            
        }
        else{
            var putBody = JsonStringifyUpdate(name,houseName,city,state,pin,phoneNumber,salary,post);
            UpdateStaff(staffId,putBody)
            .then(()=>{
                ToggleFormPopup(1);
                ToggleConfirmPopUp();
                ShowStaffPage(staffType);
            });
            
        }
    }
  
}



function JsonStringifyUpdate(name,houseName,city,state,pin,phoneNumber,salary,specificData){
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

    return result;

}


function JsonStringifyCreateAdminSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType){
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

    return result;
}

function JsonStringifyCreateTeacher(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary){
    var result = JSON.stringify(
        {
            Subject: subject,
            AssignedClass: classAssigned,
            
            Name: name,
            Address: {
                HouseName: houseName,
                City: city,
                State: state,
                Pin: 123231
            },
            PhoneNumber: phoneNumber,
            Salary: 25000.0,
            StaffType: 0
        }

        );

    return result;

}

