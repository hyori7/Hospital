using System;
using System.Web.UI;
using DataTier;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web;
using PDFBuilder;
using iTextSharp.text;

namespace BusinessTier
{
	abstract public class BasePage : Page
	{
		private Data param = null;
		protected Data Param
		{
			get
			{
				param = RequestManager.Form(Request);
				if (param.Count == 0)
				{
					param = RequestManager.Param(Request);
				}
				
				return param;
			}
		}

		public BasePage()
			: base()
		{
		}
		/// <summary>
		/// redirect url
		/// </summary>
		/// <param name="url"></param>
		public void go(String url)
		{
			Response.Redirect(url);
		}

		/// <summary>
		/// default page Load method
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Page_Load(object sender, EventArgs e)
		{
			SetInfo();
			Fire(sender, e);
		}

		/// <summary>
		/// set a default information of the site using xml
		/// </summary>
		protected void SetInfo()
		{
			if (XMLLoader.IsLoaded == false)
			{
				XMLLoader.Path = Server.MapPath("~/App_Data/config.xml");
				Paging.RowSize = int.Parse(XMLLoader.getValue("paging", "rowSize"));
				Paging.PageSize = int.Parse(XMLLoader.getValue("paging", "pageSize"));
				String source = XMLLoader.getValue("database", "dataSource");
				String initialCatalog = XMLLoader.getValue("database", "initialCatalog");
				String security = XMLLoader.getValue("database", "security");
				String path = XMLLoader.getText("database/path");
				DBC.setDBInfo(source, initialCatalog, security, path);


				Cryptograph.Passowrd = XMLLoader.getValue("security", "password");

			}
		}

		/// <summary>
		/// alert a message and go back to prior url
		/// </summary>
		/// <param name="msg"></param>
		protected void alertAndGoback(String msg) {
			String url = "/hospital/aspx/util/goBack.aspx";
			url += "?msg=" + msg;
			Response.Redirect(url);
		}

		/// <summary>
		/// alert a message and go to a new url
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="url"></param>
		protected void alertAndGo(String msg, String url)
		{
			String urlString = "";
			urlString = "/hospital/aspx/util/go.aspx";
			urlString += "?msg=" + msg + "&url=" + url;
			Response.Redirect(urlString);
		}
		
		// Writes file to current folder
		protected String WriteFile(HtmlInputFile fileObject, string testId)
		{

			string rootPath = "~/testResult/";
			// No file
			if (fileObject.PostedFile == null)
			{
				return "NO FILE";
			}
			//get a file from a file object
			HttpPostedFile postedFile = fileObject.PostedFile;
			String guid = Guid.NewGuid().ToString();
			String tempFileName = postedFile.FileName;
			String mineType = tempFileName.Substring( tempFileName.LastIndexOf("."));
			string filePath = Server.MapPath(rootPath + testId + "_"+ guid + mineType);

			// get a length of the file
			int nfileLength = postedFile.ContentLength;
			byte[] fData = new byte[nfileLength];
			postedFile.InputStream.Read(fData, 0, nfileLength);

			//write the file on the path
			FileStream newFile = new FileStream(filePath, FileMode.Create);
			newFile.Write(fData, 0, fData.Length);
			newFile.Close();
			filePath = rootPath + testId + "_" + guid + mineType;
			return filePath;
		}

		//convert html to pdf
		protected void toPDF(string html, string path)
		{
			//Page sizes are found in iTextSharp.text.PageSize
			HtmlToPdfBuilder builder = new HtmlToPdfBuilder(PageSize.LETTER);
			HtmlPdfPage first = builder.AddPage();
			//also found at builder[0]
			first.AppendHtml(html);
			//import an entire sheet
			//builder.ImportStylesheet("c:\\stylesheets\\pdf.css");
			byte[] file = builder.RenderPdf();
			File.WriteAllBytes(path, file);
			//go(path);
		}


		protected abstract void Fire(Object sender, EventArgs e);
	}
}
