using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Server.Controls
{
    public class BetterListView : ListView
    {
        public void AddItem(string text)
        {
            this.Items.Add(new ListViewItem(text));
        }

        [DllImport("uxtheme", CharSet = CharSet.Unicode)]
        public static extern int SetWindowTheme(IntPtr hWnd, string textSubAppName, string textSubIdList);

        public BetterListView()
        {
            this.View = View.Details;
            this.DoubleBuffered = true;
            if (this.Columns.Count > 0)
            {
                Columns[0].Width = this.Width;
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetWindowTheme(this.Handle, "explorer", null);
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            if (this.Columns.Count == 1)
            {
                Columns[0].Width = this.Width - 4;

            }
            base.OnInvalidated(e);
        }

        protected override void OnColumnWidthChanging(ColumnWidthChangingEventArgs e)
        {
            if (this.Columns.Count == 1)
            {
                e.Cancel = true;
                e.NewWidth = this.Columns[e.ColumnIndex].Width;
            }
            else

                base.OnColumnWidthChanging(e);
        }
    }
}
