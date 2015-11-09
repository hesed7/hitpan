using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
namespace myControls.myTabControl
{
   /// <summary>
   /// Summary description for UserControl1.
   /// </summary>
   public class myTabControl : TabControl
   {
      ///// <summary>
      ///// Required designer variable.
      ///// </summary>
      //private System.ComponentModel.Container components = null;
      
      // �ݱ��ư�� �� �̹���
      internal Image close_Image { get; set; }
      internal Image mouseOverImage { get; set; }
      // ��ư�̹����� ������(���簢�� ������ ���μ��� ������)
      private int imageSize { get; set; }

      // ���콺 Ŀ����ġ
      private Point cursor { get; set; }

       //��Ʈ
       public Font CommonFont { get; set; }
       public Font mOverFont { get; set; }

      #region ������
      /// <summary>
      /// �� ��Ʈ�� ����
      /// �� �巡�׿���� ���
      /// �� �ݱ��ư ���
      /// </summary>
      /// <param name="closeImagePath">�ݱ��ư �̹��� ���</param>
      /// <param name="mouseOverImagePath">���콺���� �̹����� ������ �̹��� ���</param>
      /// <param name="imageSize">�̹��� ������</param>
      /// <param name="DragSafeAreaSize">�巡�� �ؼ� �� �и� ��ų�� �� �и� ���� ���� ũ��</param>
      public myTabControl(string closeImagePath, string mouseOverImagePath,Font CommonFont,Font mOverFont, int imageSize)
          : base()
      {
          // This call is required by the Windows.Forms Form Designer.
          //InitializeComponent();

          this.SizeMode = TabSizeMode.Fixed;
          this.CommonFont = CommonFont;
          this.mOverFont = mOverFont;
          this.DrawMode = TabDrawMode.OwnerDrawFixed;
          this.TabStop = false;

          this.imageSize = imageSize;
          Size resize = new Size(imageSize, imageSize);
          if (mouseOverImagePath != string.Empty && mouseOverImagePath != null)
          {
              this.mouseOverImage = new Bitmap(Image.FromFile(mouseOverImagePath), resize);
          }
          this.close_Image = new Bitmap(Image.FromFile(closeImagePath), resize);         

          //�̺�Ʈ �ڵ鷯 
          this.DrawItem += myTabControl_DrawItem;
          this.MouseDown += myTabControl_MouseDown;
          this.MouseUp += myTabControl_MouseUp;
          this.MouseHover += myTabControl_MouseHover;
          this.MouseLeave += myTabControl_MouseLeave;
          this.MouseMove += myTabControl_MouseMove;
      } //End of ctor


      /// <summary>
      /// �� ��Ʈ�� ����
      /// �� �巡�׿���� ���
      /// �� �ݱ��ư ���
      /// </summary>
      /// <param name="closeImagePath">�ݱ��ư �̹��� ���</param>
      /// <param name="mouseOverImagePath">���콺���� �̹����� ������ �̹��� ���</param>
      /// <param name="imageSize">�̹��� ������</param>
      /// <param name="DragSafeAreaSize">�巡�� �ؼ� �� �и� ��ų�� �� �и� ���� ���� ũ��</param>
      public myTabControl(Image close_Image, Image mouseOverImage, Font CommonFont, Font mOverFont, int imageSize)
          : base()
      {
          // This call is required by the Windows.Forms Form Designer.
          //InitializeComponent();

          this.CommonFont = CommonFont;
          this.mOverFont = mOverFont;

          this.SizeMode = TabSizeMode.Normal;
          this.DrawMode = TabDrawMode.OwnerDrawFixed;
          this.TabStop = false;
          this.close_Image = close_Image;
          if (mouseOverImage != null)
          {
              this.mouseOverImage = mouseOverImage;
          }
          this.imageSize = imageSize;

          //�̺�Ʈ �ڵ鷯 
          this.DrawItem += myTabControl_DrawItem;
          this.MouseDown += myTabControl_MouseDown;
          this.MouseUp += myTabControl_MouseUp;
          this.MouseHover += myTabControl_MouseHover;
          this.MouseLeave += myTabControl_MouseLeave;
          this.MouseMove += myTabControl_MouseMove;
      } //End of ctor 
      #endregion

      #region ���콺 ���� , ������ 
      void myTabControl_MouseLeave(object sender, EventArgs e)
      {
          SetTabTitleImage(close_Image, GetTabIDX_MouseOver(),CommonFont);
      }
      void myTabControl_MouseHover(object sender, EventArgs e)
      {
          SetTabTitleImage(mouseOverImage, GetTabIDX_MouseOver(),mOverFont);
      } 
      #endregion

      #region �������� �ݱ��ư ���� �� �۵� ��Ʈ��
      void myTabControl_DrawItem(object sender, DrawItemEventArgs e)
      {
          SetTabTitleImage(close_Image,CommonFont);
      }

      /// <summary>
      /// �������� �ݱ��ư �������� �����ϰ� ó���Ѵ�
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private bool CloseButton_Act(object sender, MouseEventArgs e)
      {
          bool isClose = false;
          int i = 0;
          Rectangle rect;
          foreach (TabPage page in this.TabPages)
          {
              //�̹��� ��ǥ ������ Ŭ���� ������ �ľ��Ѵ�
              try
              {
                  rect = GetImageRect(this.GetTabRect(i));
                  if (rect.Contains(new Point(e.X, e.Y)))
                  {
                      if (page != null)
                      {
                          this.TabPages.Remove(page);
                          isClose = true;
                          break;
                      }
                  }
              }
              catch (ArgumentOutOfRangeException)
              {

                  continue;
              }
              i++;
          }
          return isClose;
      } 
      #endregion

      #region �������� ������
      public bool isClosing { get; set; }
      public Rectangle DragSafeArea { get; set; }
      void myTabControl_MouseDown(object sender, MouseEventArgs e)
      {
          //�ݱ� �̹����� Ŭ���ߴ��� �����ϰ� �ݱ� �̹��� ��ư�� Ŭ���� ��쿡�� �ش� ������ �����Ѵ�
          if (CloseButton_Act(sender,e))
          {
              isClosing = true;
              return;
          }
          //�ݱ� �̹����� Ŭ���� ��찡 �ƴҶ�
          if (e.Button == MouseButtons.Left)
          {
                isClosing = false;
                DragSafeArea = this.GetTabRect(GetTabIDX_MouseOver());
          }
      }
      void myTabControl_MouseUp(object sender, MouseEventArgs e)
      {
          if (isClosing)
          {
              return;
          }
          try
          {
              //�巡�� �������� �ȿ��� ���콺 ��ư�� �� ���̸� ���̻� �������� �ʴ´�
              if (DragSafeArea.Contains(new Point(e.X, e.Y)))
              {
                  return;
              }
              DivideTabPage();

          }
          catch (Exception)
          {
              throw;

          }
          finally 
          {
              DragSafeArea = new Rectangle();        
          }
      }//End of myTabControl_MouseUp

      /// <summary>
      /// �������� ������
      /// </summary>
      private void DivideTabPage()
      {
          if (TabPages.Count<=0)
          {
              return;
          }
          if (this.SelectedTab==null)
          {
              this.SelectedTab = this.TabPages[0];
          }
          frmTabContainer container = new frmTabContainer(this.SelectedTab,this);
          container.Show();
      }


      #endregion
     
      #region ����

        /// <summary>
        /// �� ������ Ÿ��Ʋ�� �̹��� ����
        /// </summary>
        /// <param name="image"></param>
        private void SetTabTitleImage(Image image,Font font)
        {
            if (image==null)
            {
                throw new NullReferenceException("�̹��� ���� ��ü�� null �Դϴ�");
            }
            if (this.mouseOverImage != null)
            {
                Graphics g = this.CreateGraphics();
                SolidBrush brush = new SolidBrush(Color.Black);
                Rectangle rect;
                for (int i = 0; i < this.TabCount; i++)                                                 // TabControl �� ���Ե� ��� Page ���� ���鼭
                {
                    rect = this.GetTabRect(i);
                    g.DrawImage(image, rect.Right - 4 - image.Width, rect.Top + 3);      // ���뿡 �̹����� �׸�. (������ư)
                    g.DrawString(this.TabPages[i].Text, font, brush, (RectangleF)(this.GetTabRect(i)));  // �̰� TabPage �̸��� �׸�
                   // this.TabPages[i].Width = Convert.ToInt32(image.Width + (this.TabPages[i].Text.Length * font.Size) * 0.75);
                }
            }//End of if
        }


        /// <summary>
        /// �� ������ Ÿ��Ʋ�� �̹��� ����
        /// </summary>
        /// <param name="image"></param>
        private void SetTabTitleImage(Image image,int pageIDX,Font font)
        {
            try
            {
                if (image == null)
                {
                    throw new NullReferenceException("�̹��� ���� ��ü�� null �Դϴ�");
                }
                if (pageIDX <= 0)
                {
                    pageIDX = 0;
                }

                if (this.mouseOverImage != null)
                {
                    Graphics g = this.CreateGraphics();
                    SolidBrush brush = new SolidBrush(Color.Black);
                    Rectangle rect;

                    rect = this.GetTabRect(pageIDX);
                    g.DrawImage(image, rect.Right - 4 - image.Width, rect.Top + 3);      // ���뿡 �̹����� �׸�. (������ư)
                    this.TabPages[pageIDX].Font = font;                    
                }//End of if
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }


        /// <summary>
        /// �ڿ�����
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                foreach (TabPage page in this.TabPages)
                {
                    if (page != null)
                    {
                        foreach (Component control in page.Controls)
                        {
                            if (control != null)
                            {
                                control.Dispose();
                            }
                        }
                        page.Dispose();
                    }
                }
            }
            base.Dispose(disposing);
        }


        /// <summary>
        ///  �̹��� ���� ���ϱ�
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private Rectangle GetImageRect(Rectangle rect)
        {
            Rectangle myRect = new Rectangle(rect.Right - 4 - imageSize, rect.Top + 3, imageSize, imageSize);
            return myRect;
        }

       /// <summary>
       /// ���콺 ������ ���� idx�� ��ȯ
       /// </summary>
       /// <returns></returns>
        private int GetTabIDX_MouseOver() 
        {
            
            int idx=0;           
            for (int i = 0; i < this.TabPages.Count; i++)
            {
                Rectangle tabArea = this.GetTabRect(i);
                if (tabArea.Contains(cursor))
                {
                    idx = i;
                    break;
                }
            }
            return idx;                        
        }

        
        void myTabControl_MouseMove(object sender, MouseEventArgs e)
        {
            cursor = e.Location;
        }

        #region �������� ���ϱ�
       /// <summary>
       /// �������� �߰��ϱ�
       /// </summary>
       /// <param name="pageTitle">�������� ��ܿ� �� Ÿ��Ʋ</param>
       /// <param name="container">���������� �� ��Ʈ�ѵ��� ��� �ִ� �����̳���Ʈ��(�г� ��)</param>
        public void AddTabPage(string pageTitle, Control container)
        {
            if (CheckTabPages(this, pageTitle))
            {
                //�̹� �����ϴ� ���
                return;
            }

            myTabPage tp = new myTabPage();
            tp.Controls.Add(container);
            tp.Text = pageTitle;

            container.Visible = true;
            container.Dock = DockStyle.Fill;
            tp.AutoScroll = true;
            tp.AllowDrop = true;
            tp.Height = tp.Controls[0].Height;
            tp.Controls[0].Width = tp.Width;
            tp.Show();
            this.TabPages.Add(tp);

            //ù��° �� �������� �⺻������ �������� �� ������ �̹Ƿ� �̸� ���õ� �� �������� ����
            this.SelectedIndex = 0;
        }


       /// <summary>
       /// �������̳ʿ� ������ ���������� �ִ��� ����
       /// </summary>
       /// <param name="tabContainer">�� �������� ��� �ִ� �� �����̳�</param>
       /// <param name="titleText">�� �������� Ÿ��Ʋ</param>
       /// <returns>������ �������� ������ True ������ False</returns>
        private bool CheckTabPages(TabControl tabContainer, string titleText)
        {
            bool isExist = false;
            foreach (TabPage page in tabContainer.TabPages)
            {
                if (page.Text.Replace(" ",string.Empty) == titleText.Replace(" ",string.Empty))
                {
                    isExist = true;
                    break;
                }
            }
            return isExist;
        }
        #endregion(�������� ���ϱ�)
      #endregion(����)

        /// <summary>
        /// �θ� �гο� ����Ʈ�ѷ��� ���δ�
        /// </summary>
        /// <param name="parent">�θ��г�</param>
        /// <param name="containerStyle">�θ��г��� ������Ÿ��</param>
        public void AttachTabContainer(Panel parent ,BorderStyle parentStyle)
        {
            parent.BorderStyle = parentStyle;
            parent.Controls.Add(this);
            this.Dock = DockStyle.Fill;
        }
   }
}

