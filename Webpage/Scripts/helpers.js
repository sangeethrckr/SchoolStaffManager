function ShowStaffPage(staffType){

    var url;
    switch(parseInt(staffType)){
        case 0:
            url = "http://schoolstaff.dev.com/api/staff?staffType=teaching";
            break;
        case 1:
            url = "http://schoolstaff.dev.com/api/staff?staffType=admin";
            break;
        case 2:
            url = "http://schoolstaff.dev.com/api/staff?staffType=support";
            break;
    }
    
    var divContainer = document.getElementById("showData");
    divContainer.innerHTML = "";
    var addStaffButton = document.createElement("input");
    addStaffButton.type = "button";
    addStaffButton.value = "Add Staff";
    addStaffButton.id = "addStaffButton";
    divContainer.appendChild(addStaffButton);

    GetStaff(url)
    .then(data => 
        {
            table = CreateTableFromJSON(data);
            table.setAttribute('id','staffTable');
            
            divContainer.appendChild(table);
        });      

    document.getElementById("addStaffButton").onclick = function(){
        if(staffType == 0){
            ToggleCreateTeacherPopUp(1);
        }
        else{
            ToggleCreateAdminOrSupportStaffPopUp(1);
        }
    };

    document.getElementById("submit").onclick = function(){
        if(this.dataset.task == 1){
            console.log('create');
            CreateAdminOrSupportStaff(staffType,1);
        }
        else{
            
            CreateAdminOrSupportStaff(staffType,2,this.dataset.staffId);
        }
    };

    document.getElementById("submit2").onclick = function(){
        //CreateTeachingStaff(staffType);
        if(this.dataset.task == 1){
            console.log('create');
            CreateTeachingStaff(staffType,1);
        }
        else{
            
            CreateTeachingStaff(staffType,2,this.dataset.staffId);
        }
    };
}


function CreateAdminOrSupportStaff(staffType,task,staffId){
    var name = document.getElementById("name").value;
    var houseName = document.getElementById("houseName").value;
    var city = document.getElementById("city").value;
    var state = document.getElementById("state").value;
    var pin = parseInt(document.getElementById("pin").value);
    var phoneNumber = document.getElementById("phoneNumber").value;
    var salary = parseFloat(document.getElementById("salary").value);
    var post = document.getElementById("post").value;
    
    

    

    if(task == 1){
        var postBody = CreatePostMethodBodyForAdminAndSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType);
        CreateStaff(postBody)
        .then(result=>
            {
                console.log(result);
                
            })
        .then(() =>{
            ToggleCreateAdminOrSupportStaffPopUp();
            ShowStaffPage(staffType);
        });
    }
    else{
        var putBody = CreatePutMethodBody(name,houseName,city,state,pin,phoneNumber,salary,post);
        UpdateStaff(staffId,putBody)
        .then(result=>{
            console.log(result);
            })
        .then(()=>{
            ToggleCreateAdminOrSupportStaffPopUp();
            ShowStaffPage(staffType);
        });
        //console.log('update' + staffId);
    }
    
    
    
}

function CreateTeachingStaff(staffType,task,staffId){
    var postBody;

    var name = document.getElementById("name2").value;
    var houseName = document.getElementById("houseName2").value;
    var city = document.getElementById("city2").value;
    var state = document.getElementById("state2").value;
    var pin = parseInt(document.getElementById("pin2").value);
    var phoneNumber = document.getElementById("phoneNumber2").value;
    var salary = parseFloat(document.getElementById("salary2").value);
    var subject = document.getElementById("subject2").value;
    var classAssigned = document.getElementById("classAssigned2").value;
    
    

    if(task == 1){
        postBody = CreatePostMethodBodyForTeaching(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary);
        CreateStaff(postBody)
        .then(result=>
            {
                console.log(result);
                
            })
        .then(() =>{
            ToggleCreateTeacherPopUp();
            ShowStaffPage(staffType);
        });
    }
    else{
        var putBody = CreatePutMethodBody(name,houseName,city,state,pin,phoneNumber,salary,classAssigned);
        UpdateStaff(staffId,putBody)
        .then(result=>{
            console.log(result);
            })
        .then(()=>{
            ToggleCreateTeacherPopUp();
            ShowStaffPage(staffType);
        });
        //console.log('update' + staffId);
    }
    
    
    
}

function CreatePutMethodBody(name,houseName,city,state,pin,phoneNumber,salary,specificData){
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


function CreatePostMethodBodyForAdminAndSupport(post,name,houseName,city,state,pin,phoneNumber,salary,staffType){
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

function CreatePostMethodBodyForTeaching(subject,classAssigned,name,houseName,city,state,pin,phoneNumber,salary){
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



function ToggleCreateAdminOrSupportStaffPopUp(task,staffId,name,houseName,city,state,pin,phoneNumber,salary,post) {
    var popup = document.getElementById("myPopup");
    popup.classList.toggle("show");
    document.getElementById("submit").dataset.task = task;
    document.getElementById("submit").dataset.staffId = staffId;
    if(task == 2){
    document.getElementById("name").value = name;
    document.getElementById("houseName").value = houseName;
    document.getElementById("city").value = city;
    document.getElementById("state").value = state;
    document.getElementById("pin").value = pin;
    document.getElementById("phoneNumber").value = phoneNumber;
    document.getElementById("salary").value = salary;
    document.getElementById("post").value = post;
    }
  }

function ToggleCreateTeacherPopUp(task,staffId,name,houseName,city,state,pin,phoneNumber,salary,subject,classAssigned) {
    var popup = document.getElementById("myPopup2");
    popup.classList.toggle("show");
    document.getElementById("submit2").dataset.task = task;
    document.getElementById("submit2").dataset.staffId = staffId;
    if(task == 2){
        document.getElementById("name2").value = name;
        document.getElementById("houseName2").value = houseName;
        document.getElementById("city2").value = city;
        document.getElementById("state2").value = state;
        document.getElementById("pin2").value = pin;
        document.getElementById("phoneNumber2").value = phoneNumber;
        document.getElementById("salary2").value = salary;
        document.getElementById("subject2").value = subject;
        document.getElementById("classAssigned2").value = classAssigned;
        }
}

function ToggleConfirmDeletePopUp(staffId,staffType) {
var popup = document.getElementById("delConfirm");
popup.classList.toggle("show");
document.getElementById("confirmDel").onclick = function(){
    DeleteStaffFromTable(staffId,staffType);
    //alert(staffId);
};
}

  
function DeleteStaffFromTable(staffId,staffType){
    DeleteStaff(staffId)
    .then(data=>{
        console.log(data);
    })
    .then(() =>{
        ToggleConfirmDeletePopUp(staffId);
        ShowStaffPage(staffType);
    });
    
}
  
