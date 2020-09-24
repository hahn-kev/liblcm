// Copyright (c) 2014-2017 SIL International
// This software is licensed under the LGPL, version 2.1 or later
// (http://www.gnu.org/licenses/lgpl-2.1.html)

using System.IO;
using System.Xml;
using NUnit.Framework;
using STU = SIL.TestUtilities;

namespace SIL.LCModel
{
	class GoldEticTests
	{
		[Test]
		public void AllPOSTemplatePossibilityItemsHaveGUIDs()
		{
			var posFilePath = Path.Combine(TestDirectoryFinder.TemplateDirectory, "POS.xml");
			STU.AssertThatXmlIn.File(posFilePath).HasNoMatchForXpath("//PartOfSpeech[not(@guid)]");
		}

		[Test]
		public void AllPOSTemplatePossibilityItemsMatchGoldEticStandard()
		{
			var posFilePath = Path.Combine(TestDirectoryFinder.TemplateDirectory, "POS.xml");
			var goldEticFilePath = Path.Combine(TestDirectoryFinder.TemplateDirectory, "GOLDEtic.xml");
			var dom = new XmlDocument();
			// Load the intitial Part of Speech list.
			dom.Load(posFilePath);
			var posNodes = dom.SelectNodes("//PartOfSpeech[@guid]");
			foreach(XmlElement posNode in posNodes)
			{
				var guid = posNode.Attributes["guid"];
				var catalogIdNode = (XmlElement)posNode.SelectSingleNode("CatalogSourceId/Uni");
				Assert.NotNull(catalogIdNode, "Part of speech list item missing CatalogSourceId: " + posNode.OuterXml);
				var catalogId = catalogIdNode.InnerText;
				var posMatchingXpath = string.Format("//item[@id='{0}' and @guid='{1}']", catalogId, guid.Value);
				STU.AssertThatXmlIn.File(goldEticFilePath).HasSpecifiedNumberOfMatchesForXpath(posMatchingXpath, 1);
			}
		}
	}
}
