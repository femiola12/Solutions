<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="javescriptPlayGround.aspx.cs" Inherits="Lab_25_ASP_First_Website.javescriptPlayGround" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>

        var x = 0;
        function runSomeFunction()
        {
            x++
            alert('the value of x is ' + x)
           
            var name1 = confirm('are you a waste man');
            var name = prompt('Yes you are Whats your name BIG MAN???');
            if (name)
            {
                alert('Thanks ' + name + ' YOU DICKHEAD ');

            }
            else {
                alert('no problem  ' + name + ' YOU are not DICKHEAD ');
            }
            console.log(name1);
            console.log(name);
        }

    </script>

    <button onclick="runSomeFunction()"> Run some Test data</button>
    <div id=" test-data"></div>


</asp:Content>
