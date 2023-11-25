using System;
using System.Reflection;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Printing;
using BilisselBeceriler.BelgeEditor.Library.Types;

namespace BilisselBeceriler.BelgeEditor.Library.Helpers
{
    public class PageRangeDocumentPaginator : DocumentPaginator
    {
        private readonly int _startIndex;
        private readonly int _endIndex;
        private readonly DocumentPaginator _paginator;
        private readonly Size _targetSize;
        private Size _sourceSize;
        private PageOrientation _sourceOrientation;
        public void Arrange()
        {
            return;
            for (int i = 0; i < PageCount; i++)
            {
                
                var page = GetPage(i);
                var fixedPage = (ContainerVisual)page.Visual;
                var pageContent = ((ContainerVisual)page.Visual).Children[0] as Grid;
                if (pageContent != null)
                {
                    var kaynak = new Size(pageContent.Width, pageContent.Height);
                    #region set Fixed Page

                    // Add visual, measure/arrange page.
                    //fixedPage.Width = _sourceSize.Width;
                    //fixedPage.Height = _sourceSize.Height;
                    //fixedPage.Measure(_sourceSize);
                    //fixedPage.Arrange(new Rect(new Point(), _sourceSize));
                    //fixedPage.UpdateLayout();
                    #endregion

                    #region Clear Content Transform
                    double sc = ScaleHesapla(kaynak, _sourceSize);
                    var tg = new TransformGroup();
                    var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };

                    tg.Children.Add(sct);
                    pageContent.LayoutTransform = null;
                    pageContent.LayoutTransform = tg;
                    pageContent.UpdateLayout();
                }
                    #endregion
            }
        }

        public PageRangeDocumentPaginator(DocumentPaginator paginator, PageRange pageRange, PrintTicket printTicket, Thickness marj)
        {
            if ((printTicket.PageMediaSize.Width != null) && (printTicket.PageMediaSize.Height != null))
                _targetSize = new Size(printTicket.PageMediaSize.Width.Value,
                                       printTicket.PageMediaSize.Height.Value);
            if (
                 (pageRange.PageFrom == 1 && pageRange.PageTo == 0) ||
                 (pageRange.PageFrom == 0 && pageRange.PageTo == 0) || // Not Set
                  pageRange == new PageRange()
               )
            {
                pageRange = new PageRange(1, paginator.PageCount);
            }
            _startIndex = pageRange.PageFrom - 1;
            _endIndex = pageRange.PageTo - 1;
            _paginator = paginator;

            // Adjust the _endIndex
            _endIndex = Math.Min(_endIndex, _paginator.PageCount - 1);

            for (var i = 0; i < PageCount; i++)
            {

                var page = GetPage(i);
                var fixedPage = page;
                //var pageContent = ((ContainerVisual)page.Visual).Children[0] as Grid;
                //if (pageContent != null)
                //{
                    //var kaynak = new Size(pageContent.Width, pageContent.Height);
                    //_sourceSize.Width = fixedPage.Size.Width;
                    //_sourceSize.Height = fixedPage.Size.Height;
                    //_sourceOrientation = printTicket.PageOrientation.Value;
                    #region set Fixed Page
                    // fixedPage.Width = _targetSize.Width;
                    // fixedPage.Height = _targetSize.Height;
                    // Add visual, measure/arrange page.
                    #endregion

                    #region Scale Page Content
                    //double sc = ScaleHesapla(kaynak, _targetSize);
                    //var tg = new TransformGroup();
                    //var sct = new ScaleTransform(sc, sc) { CenterX = 0, CenterY = 0 };
                    //tg.Children.Add(sct);

                    //pageContent.Margin = marj;
                    //pageContent.LayoutTransform = null;
                    //pageContent.LayoutTransform = tg;
                    //pageContent.UpdateLayout();
                    #endregion
                //}
            }
        }
        public PageRangeDocumentPaginator(DocumentPaginator paginator, PageRange pageRange)
        {
            if (
                 (pageRange.PageFrom == 1 && pageRange.PageTo == 0) ||
                 (pageRange.PageFrom == 0 && pageRange.PageTo == 0) || // Not Set
                  pageRange == new PageRange()
               )
            {
                pageRange = new PageRange(1, paginator.PageCount);
            }
            _startIndex = pageRange.PageFrom - 1;
            _endIndex = pageRange.PageTo - 1;
            _paginator = paginator;

            // Adjust the _endIndex
            _endIndex = Math.Min(_endIndex, _paginator.PageCount - 1);
        }
        public override sealed DocumentPage GetPage(int pageNumber)
        {
            var page = _paginator.GetPage(pageNumber + _startIndex);

            // Create a new ContainerVisual as a new parent for page children
            var cv = new ContainerVisual();
            if (page.Visual is FixedPage)
            {
                foreach (var child in ((FixedPage)page.Visual).Children)
                {
                    var childClone = Common.CloneUsingXaml(child) as Grid;
                    var parentField = childClone.GetType().GetField("_parent", BindingFlags.Instance | BindingFlags.NonPublic);
                    if (parentField != null)
                    {
                        parentField.SetValue(childClone, null);
                    }
                    cv.Children.Add(childClone);
                    childClone.UpdateLayout();
                    // Make a shallow clone of the child using reflection
                    //var childClone = (UIElement)child.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic).Invoke(child, null);
                    // Setting the parent of the cloned child to the created ContainerVisual by using Reflection.
                    // WARNING: If we use Add and Remove methods on the FixedPage.Children, for some reason it will
                    //          throw an exception concerning event handlers after the printing job has finished.
                    //var parentField = childClone.GetType().GetField("_parent", BindingFlags.Instance | BindingFlags.NonPublic);
                    //if (parentField != null)
                    //{
                    //    parentField.SetValue(childClone, null);
                    //    cv.Children.Add(childClone);
                    //}
                }

                return new DocumentPage(page.Visual, page.Size, page.BleedBox, page.ContentBox);
            }

            return page;
        }

        public override bool IsPageCountValid
        {
            get { return true; }
        }

        public override sealed int PageCount
        {
            get
            {
                if (_startIndex > _paginator.PageCount - 1)
                    return 0;
                if (_startIndex > _endIndex)
                    return 0;

                return _endIndex - _startIndex + 1;
            }
        }

        public override Size PageSize
        {
            get { return _paginator.PageSize; }
            set { _paginator.PageSize = value; }
        }

        public override IDocumentPaginatorSource Source
        {
            get { return _paginator.Source; }
        }

        private static double ScaleHesapla(Size kaynak, Size hedef)
        {
            double scw = hedef.Width / kaynak.Width;
            double sch = hedef.Height / kaynak.Height;
            if (scw < sch)
            {
                return scw;
            }
            return sch;
        }
    }
}
