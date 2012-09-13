<?xml version="1.0" encoding="UTF-8"?>
<!DOCTYPE xsl:stylesheet [
  <!ENTITY nbsp "&#x00A0;">
]>
<xsl:stylesheet
version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:msxml="urn:schemas-microsoft-com:xslt"
xmlns:umbraco.library="urn:umbraco.library"
xmlns:Exslt.ExsltCommon="urn:Exslt.ExsltCommon"
xmlns:Exslt.ExsltDatesAndTimes="urn:Exslt.ExsltDatesAndTimes"
xmlns:Exslt.ExsltMath="urn:Exslt.ExsltMath"
xmlns:Exslt.ExsltRegularExpressions="urn:Exslt.ExsltRegularExpressions"
xmlns:Exslt.ExsltStrings="urn:Exslt.ExsltStrings"
xmlns:Exslt.ExsltSets="urn:Exslt.ExsltSets"
exclude-result-prefixes="msxml umbraco.library Exslt.ExsltCommon
Exslt.ExsltDatesAndTimes Exslt.ExsltMath Exslt.ExsltRegularExpressions
Exslt.ExsltStrings Exslt.ExsltSets ">
  <xsl:output method="xml" omit-xml-declaration="yes"/>
  <xsl:param name="currentPage"/>
  <xsl:variable name="minLevel" select="1"/>

  <xsl:variable name="Width" select="/macro/Width"/>
  <xsl:variable name="Height" select="/macro/Height"/>
  <xsl:variable name="FlashNode" select="/macro/FlashFile"/>
  <xsl:variable name="NodeName" select="$FlashNode/File/@nodename"/>
  <xsl:variable name="FilePath" select="$FlashNode/File/umbracoFile"/>

  <xsl:template match="/">
    <div id="flashContent">
      <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" align="middle">
        <xsl:attribute name="width">
          <xsl:value-of select="$Width" />
        </xsl:attribute>
        <xsl:attribute name="height">
          <xsl:value-of select="$Height" />
        </xsl:attribute>
        <xsl:attribute name="id">
          <xsl:value-of select="testhsjsh" />
        </xsl:attribute>
        <param name="movie">
          <xsl:attribute name="value">
            <xsl:value-of select="$FilePath"/>
          </xsl:attribute>
        </param>
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
        <object type="application/x-shockwave-flash" >
          <xsl:attribute name="width">
            <xsl:value-of select="$Width" />
          </xsl:attribute>
          <xsl:attribute name="height">
            <xsl:value-of select="$Height" />
          </xsl:attribute>
          <xsl:attribute name="data">
            <xsl:value-of select="$FilePath" />
          </xsl:attribute>
          
          <param name="movie">
            <xsl:attribute name="value">
              <xsl:value-of select="$FilePath"/>
            </xsl:attribute>
          </param>
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
  </xsl:template>
</xsl:stylesheet>