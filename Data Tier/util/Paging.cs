using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTier
{
    public class Paging
    {
        private static int rowSize = 20;
        private static int pageSize = 10;
        private static String form = "<first><previous><pages><next><end>";
        private static String btnForm = "<a href='#' <onclick>><name></a>";
        private static String onclick = "onClick=\"search(<pageNum>)\"";
        private static String firstName = "&lt;&lt;";
        private static String previousName = "&lt;";
        private static String nextName = "&gt;";
        private static String endName = "&gt;&gt;";
        private static String pageNumber = "<span class='page' <onclick>><pageNum></span>";
        private static String lastPageNumber = "<span class='page lastPage' <onclick>><pageNum></span>";
        private static String nowNumber = "<span class='page nowPage' <onclick>><pageNum></span>";


        public static String Onclick
        {
            get { return Paging.onclick; }
            set { Paging.onclick = value; }
        }

        public static int RowSize
        {
            get { return Paging.rowSize; }
            set { Paging.rowSize = value; }
        }

        public static int PageSize
        {
            get { return Paging.pageSize; }
            set { Paging.pageSize = value; }
        }

        public static String Form
        {
            get { return Paging.form; }
            set { Paging.form = value; }
        }

        public static String BtnForm
        {
            get { return Paging.btnForm; }
            set { Paging.btnForm = value; }
        }

        public static String FirstName
        {
            get { return Paging.firstName; }
            set { Paging.firstName = value; }
        }

        public static String PreviousName
        {
            get { return Paging.previousName; }
            set { Paging.previousName = value; }
        }

        public static String NextName
        {
            get { return Paging.nextName; }
            set { Paging.nextName = value; }
        }

        public static String EndName
        {
            get { return Paging.endName; }
            set { Paging.endName = value; }
        }

        public static String PageNumber
        {
            get { return Paging.pageNumber; }
            set { Paging.pageNumber = value; }
        }

        public static String LastPageNumber
        {
            get { return Paging.lastPageNumber; }
            set { Paging.lastPageNumber = value; }
        }

        public static String NowNumber
        {
            get { return Paging.nowNumber; }
            set { Paging.nowNumber = value; }
        }

        public static String make(Data data)
        {
            return make(data, rowSize, pageSize);
        }

        public static String make(Data data, int rowSize, int pageSize)
        {
            int now = data.Now;
            int total = data.RowCount;

            if (total < rowSize)
            {
                return noPage();
            }
            else if (total / rowSize < pageSize)
            {
                return onePageList(data, rowSize, pageSize);
            }
            else
            {
                return manyPages(data, rowSize, pageSize);
            }

        }

        protected static String noPage() {
            return "";
        }

        protected static String onePageList(Data data, int rowSize, int pageSize)
        {

            int now = data.Now;
            int total = data.RowCount;
            int maxPage = 0;
            String result = "";
            List<String> pageForm = new List<string>();
            result = Form.Replace("<first>", "").Replace("<end>", "");

            maxPage = (total - (total % rowSize)) / rowSize;
            if (total % rowSize > 0)
            {
                ++maxPage;
            }

            if (now == 0)
            {
                result = result.Replace("<previous>", "");
                addNextBtn(ref result, now);
            }
            else if (now == maxPage - 1)
            {
                result = result.Replace("<next>", "");
                addPreviousBtn(ref result, now);
            }
            else
            {
                addNextBtn(ref result, now);
                addPreviousBtn(ref result, now);
            }

            replacePages(ref pageForm, 0, maxPage, now);

            return addPages(result, pageForm);
        }

        protected static String manyPages(Data data, int rowSize, int pageSize)
        {
            int now = data.Now;
            int total = data.RowCount;
            int startPage = 0;
            int maxPage = 0;
            int lastPage = 0;
            String result = "";
            List<String> pageForm = new List<string>();
            //<first><previous><pages><next><end>
            startPage = (now - (now % pageSize)) / pageSize;
            lastPage = (total -( total %(rowSize*pageSize)))/ (rowSize*pageSize);
            maxPage = (total - (total % rowSize)) / rowSize;
            if (total % rowSize > 0)
            {
                ++maxPage;
            }
            if (startPage == 0)
            {
                result = Form.Replace("<first>", "");//.Replace("<previous>", "");
                addEndBtn(ref result, lastPage * pageSize);
            }
            else if (startPage == lastPage)
            {
                result = Form.Replace("<end>", "");
                addFirstBtn(ref result);
            }
            else
            {
                addFirstBtn(ref result);
                addEndBtn(ref result, maxPage);
            }

            if (now == startPage * pageSize)
            {
                result = result.Replace("<previous>", "");
                addNextBtn(ref result, now);
            }
            else if (now == maxPage)
            {
                result = result.Replace("<next>", "");
                addPreviousBtn(ref result, now);
            }
            else
            {
                addNextBtn(ref result, now);
                addPreviousBtn(ref result, now);
            }
            replacePages(ref pageForm, startPage * pageSize, (startPage * pageSize) + pageSize - 1, now);
            return addPages(result, pageForm);
        }

        //<first><previous><pages><next><end>
        protected static void addFirstBtn(ref String result)
        {
            result = result.Replace("<first>", toButton(0, FirstName));
        }

        protected static void addEndBtn(ref String result, int pageNum)
        {
            result.Replace("<end>",toButton(pageNum, EndName));
        }

        protected static void addPreviousBtn(ref String result, int pageNum)
        {
            result.Replace("<previous>",toButton(pageNum - 1, PreviousName));
        }

        protected static void addNextBtn(ref String result, int pageNum)
        {
            result.Replace("<next>", toButton(pageNum +1, NextName));
        }

        protected static String toPageBtn(int pageNum)
        {
            return toButton(pageNum, "" + (pageNum + 1));
        }

        protected static String toButton(int pageNum, String name)
        {
            return BtnForm.Replace("<onclick>", Onclick.Replace("<pageNum>", ""+ pageNum)).Replace("<name>",name) ;
        }

        protected static String addPages(String result, List<String> list)
        {
            return result.Replace("<pages>", string.Join("", list.ToArray()));
        }

        protected static void replacePages(ref List<String> pageForm, int from, int to, int now)
        {
            for (int i = from; i < to - 1; i++)
            {
                if (i == now)
                {
                    pageForm.Add(NowNumber.Replace("<pageNum>", toPageBtn(i)));
                }
                else
                {
                    pageForm.Add(PageNumber.Replace("<pageNum>", toPageBtn(i)));
                }
            }
            pageForm.Add(LastPageNumber.Replace("<pageNum>", "" + (to - 1)));
        }
    }
}
