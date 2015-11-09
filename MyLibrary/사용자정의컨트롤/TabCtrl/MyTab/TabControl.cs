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
      
      // 닫기버튼에 들어갈 이미지
      internal Image close_Image { get; set; }
      internal Image mouseOverImage { get; set; }
      // 버튼이미지의 사이즈(정사각형 영역의 가로세로 사이즈)
      private int imageSize { get; set; }

      // 마우스 커서위치
      private Point cursor { get; set; }

       //폰트
       public Font CommonFont { get; set; }
       public Font mOverFont { get; set; }

      #region 생성자
      /// <summary>
      /// 탭 컨트롤 생성
      /// 탭 드래그엔드롭 기능
      /// 탭 닫기버튼 기능
      /// </summary>
      /// <param name="closeImagePath">닫기버튼 이미지 경로</param>
      /// <param name="mouseOverImagePath">마우스오버 이미지에 보여질 이미지 경로</param>
      /// <param name="imageSize">이미지 사이즈</param>
      /// <param name="DragSafeAreaSize">드래그 해서 탭 분리 시킬때 탭 분리 제한 영역 크기</param>
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

          //이벤트 핸들러 
          this.DrawItem += myTabControl_DrawItem;
          this.MouseDown += myTabControl_MouseDown;
          this.MouseUp += myTabControl_MouseUp;
          this.MouseHover += myTabControl_MouseHover;
          this.MouseLeave += myTabControl_MouseLeave;
          this.MouseMove += myTabControl_MouseMove;
      } //End of ctor


      /// <summary>
      /// 탭 컨트롤 생성
      /// 탭 드래그엔드롭 기능
      /// 탭 닫기버튼 기능
      /// </summary>
      /// <param name="closeImagePath">닫기버튼 이미지 경로</param>
      /// <param name="mouseOverImagePath">마우스오버 이미지에 보여질 이미지 경로</param>
      /// <param name="imageSize">이미지 사이즈</param>
      /// <param name="DragSafeAreaSize">드래그 해서 탭 분리 시킬때 탭 분리 제한 영역 크기</param>
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

          //이벤트 핸들러 
          this.DrawItem += myTabControl_DrawItem;
          this.MouseDown += myTabControl_MouseDown;
          this.MouseUp += myTabControl_MouseUp;
          this.MouseHover += myTabControl_MouseHover;
          this.MouseLeave += myTabControl_MouseLeave;
          this.MouseMove += myTabControl_MouseMove;
      } //End of ctor 
      #endregion

      #region 마우스 오버 , 릴리즈 
      void myTabControl_MouseLeave(object sender, EventArgs e)
      {
          SetTabTitleImage(close_Image, GetTabIDX_MouseOver(),CommonFont);
      }
      void myTabControl_MouseHover(object sender, EventArgs e)
      {
          SetTabTitleImage(mouseOverImage, GetTabIDX_MouseOver(),mOverFont);
      } 
      #endregion

      #region 탭페이지 닫기버튼 생성 및 작동 컨트롤
      void myTabControl_DrawItem(object sender, DrawItemEventArgs e)
      {
          SetTabTitleImage(close_Image,CommonFont);
      }

      /// <summary>
      /// 탭페이지 닫기버튼 눌럿는지 검증하고 처리한다
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
              //이미지 좌표 위에서 클릭한 것인지 파악한다
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

      #region 탭페이지 꺼내기
      public bool isClosing { get; set; }
      public Rectangle DragSafeArea { get; set; }
      void myTabControl_MouseDown(object sender, MouseEventArgs e)
      {
          //닫기 이미지를 클릭했는지 검증하고 닫기 이미지 버튼을 클릭한 경우에는 해당 로직만 수행한다
          if (CloseButton_Act(sender,e))
          {
              isClosing = true;
              return;
          }
          //닫기 이미지를 클릭한 경우가 아닐때
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
              //드래그 안전영역 안에서 마우스 버튼을 뗀 것이면 더이상 진행하지 않는다
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
      /// 탭페이지 꺼내기
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
     
      #region 공통

        /// <summary>
        /// 탭 페이지 타이틀에 이미지 세팅
        /// </summary>
        /// <param name="image"></param>
        private void SetTabTitleImage(Image image,Font font)
        {
            if (image==null)
            {
                throw new NullReferenceException("이미지 파일 객체가 null 입니다");
            }
            if (this.mouseOverImage != null)
            {
                Graphics g = this.CreateGraphics();
                SolidBrush brush = new SolidBrush(Color.Black);
                Rectangle rect;
                for (int i = 0; i < this.TabCount; i++)                                                 // TabControl 에 포함된 모든 Page 들을 돌면서
                {
                    rect = this.GetTabRect(i);
                    g.DrawImage(image, rect.Right - 4 - image.Width, rect.Top + 3);      // 이쯤에 이미지를 그림. (닫힘버튼)
                    g.DrawString(this.TabPages[i].Text, font, brush, (RectangleF)(this.GetTabRect(i)));  // 이건 TabPage 이름을 그림
                   // this.TabPages[i].Width = Convert.ToInt32(image.Width + (this.TabPages[i].Text.Length * font.Size) * 0.75);
                }
            }//End of if
        }


        /// <summary>
        /// 탭 페이지 타이틀에 이미지 세팅
        /// </summary>
        /// <param name="image"></param>
        private void SetTabTitleImage(Image image,int pageIDX,Font font)
        {
            try
            {
                if (image == null)
                {
                    throw new NullReferenceException("이미지 파일 객체가 null 입니다");
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
                    g.DrawImage(image, rect.Right - 4 - image.Width, rect.Top + 3);      // 이쯤에 이미지를 그림. (닫힘버튼)
                    this.TabPages[pageIDX].Font = font;                    
                }//End of if
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }


        /// <summary>
        /// 자원해제
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
        ///  이미지 영역 구하기
        /// </summary>
        /// <param name="rect"></param>
        /// <returns></returns>
        private Rectangle GetImageRect(Rectangle rect)
        {
            Rectangle myRect = new Rectangle(rect.Right - 4 - imageSize, rect.Top + 3, imageSize, imageSize);
            return myRect;
        }

       /// <summary>
       /// 마우스 오버된 탭의 idx를 반환
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

        #region 탭페이지 더하기
       /// <summary>
       /// 탭페이지 추가하기
       /// </summary>
       /// <param name="pageTitle">페이지의 상단에 들어갈 타이틀</param>
       /// <param name="container">탭페이지에 들어갈 컨트롤들을 담고 있는 컨테이너컨트롤(패널 등)</param>
        public void AddTabPage(string pageTitle, Control container)
        {
            if (CheckTabPages(this, pageTitle))
            {
                //이미 존재하는 경우
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

            //첫번째 탭 페이지는 기본적으로 보여지는 탭 페이지 이므로 이를 선택된 탭 페이지로 본다
            this.SelectedIndex = 0;
        }


       /// <summary>
       /// 탭컨테이너에 동일한 탭페이지가 있는지 검증
       /// </summary>
       /// <param name="tabContainer">탭 페이지를 담고 있는 탭 컨테이너</param>
       /// <param name="titleText">탭 페이지의 타이틀</param>
       /// <returns>동일한 페이지가 있으면 True 없으면 False</returns>
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
        #endregion(탭페이지 더하기)
      #endregion(공통)

        /// <summary>
        /// 부모 패널에 탭컨트롤러를 붙인다
        /// </summary>
        /// <param name="parent">부모패널</param>
        /// <param name="containerStyle">부모패널의 보더스타일</param>
        public void AttachTabContainer(Panel parent ,BorderStyle parentStyle)
        {
            parent.BorderStyle = parentStyle;
            parent.Controls.Add(this);
            this.Dock = DockStyle.Fill;
        }
   }
}

