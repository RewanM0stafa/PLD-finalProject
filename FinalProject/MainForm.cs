/*
 * Created by SharpDevelop.
 * User: AL_HRAMAIN
 * Date: 5/22/2025
 * Time: 3:21 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using com.calitha.goldparser;

namespace FinalProject
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		MyParser parser;
		//MyLexer lexer; 
		public MainForm()
		{
			
			// The InitializeComponent() call is required for Windows Forms designer support.
			
			InitializeComponent();
            parser = new MyParser("pythonProjrctPLD.cgt", listBox1);
         //   lexer = new MyLexer();
			
			// TODO: Add constructor code after the InitializeComponent() call.
			
		}
		
		void RichTextBox1TextChanged(object sender, EventArgs e)
		{
			
			
		}
		
		void ListBox1SelectedIndexChanged(object sender, EventArgs e)
		{
			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			listBox1.Items.Clear();
			parser.Parse(richTextBox1.Text);
		}
		
		
		
	
	/*
		
		void Button2Click(object sender, EventArgs e)
		{
					
          listBox1.Items.Clear();

          var tokens = lexer.Tokenize(richTextBox1.Text);

          foreach (var token in tokens)
          {
            listBox1.Items.Add(token.ToString());
          }
		}
		*/
		
		
	}
}
