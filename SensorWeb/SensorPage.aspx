<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SensorPage.aspx.cs" Inherits="SensorWeb.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>SensorSim</title>
    <meta charset="utf-8" />

    <link href="css/bootstrap.min.css" rel="stylesheet"/>
    
</head>
<body id="bodyclass">  
   <form class="form-horizontal" runat="server" id="formid">   
       <asp:scriptmanager id="ScriptManager1" runat="server" EnablePageMethods="true"/>
       <div class="container">
        <div class="row">
            <h1>Start Sending Data to Event Hub</h1>    
            <hr />
            <div class="form-group">
                <label for="sensortype1" class="col-sm-3 control-label input-lg">Sensor type</label>
                <div class="col-sm-9">
                    <select class="form-control input-lg" id="sensortype1" runat="server">
                      <option value="Temp">Temp</option>
                      <option value="Humidity">Humidity</option>
                      <option value="HeartRate">HeartRate</option>
                    </select>
                </div>
            </div>
            <div class="form-group">
                <label for="sensorunit1" class="col-sm-3 control-label input-lg">Sensor Unit of Measure</label>
                <div class="col-sm-9">
                     <input type="text" class="form-control input-lg" id="sensorunit1" placeholder="Unit of Measure" runat="server" required="required" />
                </div>          
            </div>
            <div class="form-group">
                <label for="minrange1" class="col-sm-3 control-label input-lg">Sensor data value range</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control input-lg" id="minrange1" placeholder="Min" runat="server" required="required" />  
                </div>             
            </div>
            <div class="form-group">
                <label for="maxrange1" class="col-sm-3 control-label input-lg"></label>
                <div class="col-sm-9">
                    <input type="text" class="form-control input-lg" id="maxrange1" placeholder="Max" runat="server" required="required" />
                </div> 
            </div>
            <hr />
            
            <div class="form-group">
                <label for="datafreq" class="col-sm-3 control-label input-lg">Data Frequency</label>
                <div class="col-sm-9">
                    <input type="text" class="form-control input-lg" id="datafreq" placeholder="Data Frequency in sec" runat="server" required="required" />
                </div> 
            </div>
            <asp:Button ID="SendButton" Text="Start Event Hub" CssClass="btn btn-lg btn-default center-block" OnClick="StartEH_Click" runat="server" />
        </div>
        </div>
   </form>

    


    <script src="js/jquery-1.11.3.min.js"></script>
    <!-- Include all compiled plugins (below), or include individual files as needed -->
    <script src="js/bootstrap.min.js"></script>
    
</body>
</html>
