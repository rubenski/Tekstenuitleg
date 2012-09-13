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


  <xsl:variable name="ImageNode" select="/macro/Image"/>
  <xsl:variable name="Src" select="$ImageNode/Image/umbracoFile"/>
  <xsl:variable name="Width" select="$ImageNode/Image/umbracoWidth"/>
  <xsl:variable name="Height" select="$ImageNode/Image/umbracoHeight"/>
  <xsl:variable name="NodeName" select="$ImageNode/Image/@nodeName"/>
  <xsl:variable name="Caption" select="/macro/Caption"/>
  <xsl:variable name="ShowBorder" select="/macro/ShowBorder"/>
  <xsl:variable name="Alignment" select="/macro/Alignment"/>
  <xsl:variable name="ImageClass" select="concat('image', ' ', $Alignment)" />


  <xsl:template match="/">
    <div class="image">
      <xsl:attribute name="class">
        <xsl:choose>
          <xsl:when test="$ShowBorder = 1">
            <xsl:value-of select="concat($ImageClass, ' ', 'bordered')"/>
          </xsl:when>
          <xsl:otherwise>
            <xsl:value-of select="$ImageClass"/>
          </xsl:otherwise>
        </xsl:choose>
      </xsl:attribute>
      <img>
        <xsl:attribute name="src">
          <xsl:value-of select="$Src" />
        </xsl:attribute>
        <xsl:attribute name="width">
          <xsl:value-of select="$Width" />
        </xsl:attribute>
        <xsl:attribute name="height">
          <xsl:value-of select="$Height" />
        </xsl:attribute>
        <xsl:attribute name="alt">
          <xsl:value-of select="$NodeName" />
        </xsl:attribute>
      </img>
      <xsl:if test="normalize-space($Caption) != ''">
        <p>
          <xsl:attribute name="style">
            <xsl:choose>
              <xsl:when test="$Width &lt;= 150">
                width: 150px
              </xsl:when>
              <xsl:otherwise>
                <xsl:value-of select="concat('width: ', $Width, 'px')" />
              </xsl:otherwise>
            </xsl:choose>
          </xsl:attribute>
          <xsl:value-of select="$Caption"/>
        </p>
      </xsl:if>
    </div>
  </xsl:template>
</xsl:stylesheet>