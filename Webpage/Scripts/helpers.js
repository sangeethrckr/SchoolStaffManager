function ShowStaffPage(staffType){
    currPage = 1;
    var url;
    switch(parseInt(staffType)){
        case 0:
            url = siteUrl +"/api/staff?staffType=teaching";
            document.getElementById("teaching-navButton").style.backgroundColor = "white";
            document.getElementById("teaching-navButton").style.color = "#333";
            document.getElementById("admin-navButton").style.backgroundColor = "#333";
            document.getElementById("admin-navButton").style.color = "white";
            document.getElementById("support-navButton").style.backgroundColor = "#333";
            document.getElementById("support-navButton").style.color = "white";
            break;
        case 1:
            
            url = siteUrl + "/api/staff?staffType=admin";
            document.getElementById("teaching-navButton").style.backgroundColor = "#333";
            document.getElementById("teaching-navButton").style.color = "white";
            document.getElementById("admin-navButton").style.backgroundColor = "white";
            document.getElementById("admin-navButton").style.color = "#333";
            document.getElementById("support-navButton").style.backgroundColor = "#333";
            document.getElementById("support-navButton").style.color = "white";
            break;
        case 2:
            url = siteUrl +"/api/staff?staffType=support";
            document.getElementById("teaching-navButton").style.backgroundColor = "#333";
            document.getElementById("teaching-navButton").style.color = "white";
            document.getElementById("admin-navButton").style.backgroundColor = "#333";
            document.getElementById("admin-navButton").style.color = "white";
            document.getElementById("support-navButton").style.backgroundColor = "white";
            document.getElementById("support-navButton").style.color = "#333";
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
            pagination(data);
            
        });      

    document.getElementById("addStaffButton").onclick = function(){
        ToggleFormPopup(staffType,1);
    };

    document.getElementById("submit").onclick = function(){
        if(this.dataset.task == 1){
            //console.log('create');
            FormAction(staffType,1);
        }
        else{
            ToggleConfirmPopUp(this.dataset.staffId,staffType,1);
            //FormAction(staffType,2,this.dataset.staffId);
        }
    };


}




function ToggleFormPopup(staffType,task,staffId,name,houseName,city,state,pin,phoneNumber,salary,post,subject,classAssigned) {

    var popup = document.getElementById("myPopup");
        popup.classList.toggle("show");
        if(staffType!=0){
            document.getElementById("classAssigned2").style.display = "none";
            document.getElementById("class-label").style.display = "none";
            document.getElementById("post-label").innerHTML = "Post";
            
        }
        else{
            document.getElementById("classAssigned2").style.display = "inline";
            document.getElementById("class-label").style.display = "inline";
            document.getElementById("post-label").innerHTML = "Subject";
        }
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

            if(staffType == 0){
                document.getElementById("post-subject").value = subject;
                document.getElementById("classAssigned2").value = classAssigned;
            }
            else{
                document.getElementById("post-subject").value = post;
            }

            
        }

        //FocusNavButton(staffType);
    
  }



function ToggleConfirmPopUp(staffId,staffType,ifUpdate) {

    if (ifUpdate == 1){
        
        var popup = document.getElementById("delConfirm");
        popup.classList.toggle("show");
        document.getElementById("confirm-text").innerHTML = "Selected staff will be updated. Are you sure?";
        document.getElementById("confirmDel").onclick = function(){
            //console.log("need to update");
            //return 1;
            FormAction(staffType,2,staffId);
            
        };
    }
    else{
        var popup = document.getElementById("delConfirm");
        popup.classList.toggle("show");
        document.getElementById("confirmDel").onclick = function(){
            DeleteStaffFromTable(staffId,staffType);
            //return 1;
            
        };
    }
}

  
function DeleteStaffFromTable(staffId,staffType){
    DeleteStaff(staffId)
    .then(() =>{
        ToggleConfirmPopUp(staffId);
        ShowStaffPage(staffType);
    });
    
    
}
  


