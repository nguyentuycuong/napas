﻿<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet xmlns:x="http://www.w3.org/2001/XMLSchema"
        xmlns:d="http://schemas.microsoft.com/sharepoint/dsp"
        version="1.0"
        exclude-result-prefixes="xsl msxsl ddwrt"
        xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime"
        xmlns:asp="http://schemas.microsoft.com/ASPNET/20"
        xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer"
        xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
        xmlns:msxsl="urn:schemas-microsoft-com:xslt"
        xmlns:SharePoint="Microsoft.SharePoint.WebControls"
        xmlns:ddwrt2="urn:frontpage:internal">

	<xsl:template match ="FieldRef[@FieldType='ImageUpload']" mode="URL_body">
		<xsl:param name="thisNode" select="."/>
		<xsl:variable name="desc" select="$thisNode/@URL.desc" />
		<xsl:variable name="url" select="substring-before($thisNode/@*[name()=current()/@Name],',')"/>
		<xsl:choose>
			<xsl:when test="$url=''">
			</xsl:when>
			<xsl:otherwise>
				<img onfocus="OnLink(this)" src="{$url}" alt="{$desc}" />
			</xsl:otherwise>
		</xsl:choose>
	</xsl:template>
</xsl:stylesheet>
