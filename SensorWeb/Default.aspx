<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SensorWeb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SensorSim</title>
	<meta charset="utf-8" />

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server" action="SensorPage.aspx"> 
    <div>
        <div class="container">
        <div class="row">
            <h1>Welcome to the Sensor Simulation Website!</h1>
            <hr />
            <p class="lead text-info">Please fill in the form below with your Event Hub details</p>

            <div class="form-group">
                <label for="EHName" class="input-lg">Event Hub Name</label>
                <input type="text" class="form-control input-lg" id="EHName" placeholder="Enter Event Hub Name" required="required" runat="server"/>
            </div>
            <div class="form-group">
                <label for="ConnectionString" class="input-lg">Connection String</label>
                <input type="text" class="form-control input-lg" id="ConnectionString" placeholder="Enter Your Event Hub Connection String" required="required" runat="server"/>
            </div>
            <div class="form-group">
                <label for="DisplayName" class="input-lg">Display Name</label>
                <input type="text" class="form-control input-lg" id="DisplayName" placeholder="Enter Display Name" required="required" runat="server"/>
            </div>
            <div class="form-group">
                <label for="Organisation" class="input-lg">Organisation</label>
                <input type="text" class="form-control input-lg" id="Organisation" placeholder="Enter Organisation Name" required="required" runat="server"/>
            </div>
            <div class="form-group">
                <label for="Location" class="input-lg">Location</label>
                <input type="text" class="form-control input-lg" id="Location" placeholder="Enter Location" required="required" runat="server"/>
            </div>
               <!--<button type="submit" class="btn btn-default" id="SubmitButton" onclick="Button_Click" runat="server">Submit</button> -->
            <hr />
            <asp:Button Text="Submit Event Hub Parameters" CssClass="btn btn-lg btn-default" id="Button1" runat="server"/>
        </div>
    </div>

    

    <script src="js/jquery-1.11.3.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    </div>
    </form>
</body>
</html>
