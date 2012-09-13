<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FlashMovie.ascx.cs" Inherits="Tekstenuitleg.usercontrols.FlashMovie" %>

<div id="flashMovie">
	<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" width="<%= Width %>" height="<%= Height %>" id="Mechanical waves" align="middle">
		<param name="movie" value="<%= Filename %>" />
		<param name="quality" value="high" />
		<param name="bgcolor" value="#ffffff" />
		<param name="play" value="true" />
		<param name="loop" value="true" />
		<param name="wmode" value="window" />
		<param name="scale" value="showall" />
		<param name="menu" value="true" />

		<param name="devicefont" value="false" />
		<param name="salign" value="" />
		<param name="allowScriptAccess" value="sameDomain" />
		<!--[if !IE]>-->
		<object type="application/x-shockwave-flash" data="<%= Filename %>" width="543" height="237">
			<param name="movie" value="Mechanical waves.swf" />
			<param name="quality" value="high" />
			<param name="bgcolor" value="#ffffff" />
			<param name="play" value="true" />

			<param name="loop" value="true" />
			<param name="wmode" value="window" />
			<param name="scale" value="showall" />
			<param name="menu" value="true" />
			<param name="devicefont" value="false" />
			<param name="salign" value="" />
			<param name="allowScriptAccess" value="sameDomain" />
		<!--<![endif]-->
			<a href="http://www.adobe.com/go/getflash">

				<img src="http://www.adobe.com/images/shared/download_buttons/get_flash_player.gif" alt="Get Adobe Flash player" />
			</a>
		<!--[if !IE]>-->
		</object>
		<!--<![endif]-->
	</object>
</div>