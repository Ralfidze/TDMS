<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html>
    <head>
        <title>Technical Data Managment System</title>
    </head>
    <frameset cols="25%, 75%">
        <frame name="sidebar" src="Sidebar.aspx" />
        <frameset rows="50%, 50%">
            <frame name="list" src="DocList.aspx" />
            <frame name="view" src="ViewEmpty.aspx" />
        </frameset>
    </frameset>
</html>