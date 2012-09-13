<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FlowplayerVideo.ascx.cs" Inherits="Tekstenuitleg.usercontrols.FlowplayerVideo" %>

<a  href="/static/video/<%= VideoFileName %>" style="display:block;width:<%=Width%>px;height:<%=Height%>px" id="player"></a>
<script>    flowplayer("player", "/static/flowplayer/flowplayer-3.2.7.swf", {
        clip: {
            autoPlay: false,
            autoBuffering: false,
            start: 1
        }
    });</script> 
