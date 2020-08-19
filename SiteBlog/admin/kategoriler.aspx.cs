﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace SiteBlog.admin
{
    public partial class kategoriler : System.Web.UI.Page
    {
        Sqlbaglantisi baglan = new Sqlbaglantisi();
        string kategoriID = "";
        string islem = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            kategoriID = Request.QueryString["kategoriID"];
            islem = Request.QueryString["islem"];
            if (islem=="sil")
            {
                SqlCommand cmdsil=new SqlCommand("delete from Kategori where kategoriID='"+kategoriID+"'",baglan.baglan());
                cmdsil.ExecuteNonQuery();
            }
            if (Page.IsPostBack == false)
            {
                pnl_kategoriEkle.Visible = false;
                pnl_kategoriDuzenle.Visible = false;
            }

            //kategorileri data liste çekme

            SqlCommand cmdkgetir = new SqlCommand("select*from Kategori", baglan.baglan());
            SqlDataReader drkgetir = cmdkgetir.ExecuteReader();
            dl_kategoriGetir.DataSource = drkgetir;
            dl_kategoriGetir.DataBind();
        }

        protected void btn_kategöriArti_Click(object sender, EventArgs e)
        {
            pnl_kategoriEkle.Visible = true;
        }

        protected void btn_kategoriEksi_Click(object sender, EventArgs e)
        {
            pnl_kategoriEkle.Visible = false;
        }

        protected void btn_kategoriEkle_Click(object sender, EventArgs e)
        {
            if (fu_kategoriResim.HasFile)//içinde resim varsa kategori ekleme yapılır
            {


                SqlCommand cmdkategoriekle = new SqlCommand("insert into Kategori(kategoriAd,kategoriSira,kategoriResim) Values('" + txt_kategoriAdi.Text + "','" + txt_sira.Text + "','/kresim/" + fu_kategoriResim.FileName + "')", baglan.baglan());
                cmdkategoriekle.ExecuteNonQuery();
                Response.Redirect("kategoriler.aspx");
                fu_kategoriResim.SaveAs(Server.MapPath("/kresim/" + fu_kategoriResim.FileName));

            }
            else
                btn_kategoriEkle.Text = "Resim Ekle";
        }

        protected void btn_kategoriduzenleArtı_Click(object sender, EventArgs e)
        {
            pnl_kategoriDuzenle.Visible = true;
        }

        protected void btn_kategoriduzenleEksi_Click(object sender, EventArgs e)
        {
            pnl_kategoriDuzenle.Visible = false;
        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btn_kategoriduzenlearti_Click(object sender, EventArgs e)
        {
            pnl_kategoriDuzenle.Visible = true;
        }

        protected void btn_kategoriduzenleEksi_Click1(object sender, EventArgs e)
        {
            pnl_kategoriDuzenle.Visible = false;
        }

        protected void dl_kategoriGetir_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}