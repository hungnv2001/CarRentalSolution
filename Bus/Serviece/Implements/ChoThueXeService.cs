﻿using Dal.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal.Modal;
using System.ComponentModel.DataAnnotations;

namespace Bus.Serviece.Implements
{
    public class ChoThueXeService
    {
        XeRepo xeRepo = new XeRepo();
        HoaDonChiTietRepo hoaDonChiTietRepo = new HoaDonChiTietRepo();
        BaoDuongRepo baoDuongRepo = new BaoDuongRepo();
        Xe_BaoHiemRepo xe_BaoHiemRepo = new Xe_BaoHiemRepo();
        HangXeRepo hangXeRepo = new HangXeRepo();
        LoaiXeRepo loaiXeRepo = new LoaiXeRepo();
        GiayToTheChapRepo giayToRepo = new GiayToTheChapRepo();
        TaiSanTheChapRepo taiSanRepo = new TaiSanTheChapRepo();
        KhachHangRepo khachHangRepo = new KhachHangRepo();
        NguoiThanRepo nguoiThanRepo = new NguoiThanRepo();
        List<Xe> lstXe;
        List<HoaDonChiTiet> lstHoaDonChitiet;
        List<BaoDuong> lstBaoDuong;
        List<XeBaoHiem> lstXeBaoHiem;
        List<HangXe> lstHangXe;
        List<LoaiXe> lstLoaiXe;
        List<GiayToTheChap> lstGiayToTheChap;
        List<TaiSanTheChap> lstTaiSan;
        List<KhachHang> lstKhachHang;
        List<NguoiThan> lstNguoiThan;
        public ChoThueXeService()
        {
            lstXe = xeRepo.GetXe();
            lstHoaDonChitiet = hoaDonChiTietRepo.GetALL();
            lstBaoDuong = baoDuongRepo.GetALL();
            lstXeBaoHiem = xe_BaoHiemRepo.GetAll();
            lstHangXe = hangXeRepo.GetALL();
            lstLoaiXe = loaiXeRepo.GetALL();
            lstTaiSan = taiSanRepo.GetALL();
            lstGiayToTheChap = giayToRepo.GetALL();
            lstKhachHang = khachHangRepo.GetALL();
            lstNguoiThan = nguoiThanRepo.GetALL();
        }

        public bool CreateKH(KhachHang khachHang, NguoiThan nguoiThan)
        {

            try
            {
                 bool addKH= khachHangRepo.Create(khachHang);
                bool addNT = nguoiThanRepo.Create(nguoiThan);
                lstNguoiThan.Add(nguoiThan);
                lstKhachHang.Add(khachHang);
                return true;
            }
            catch (Exception)
            {

                return false;
            }


        }

        public List<Xe> DataXe(DateTime startDate, DateTime endDate, int minPrice, int maxPrice)
        {
            var result = from xe in lstXe
                         join hd in lstHoaDonChitiet on xe.ID equals hd.IdXe
                         join bd in lstBaoDuong on xe.ID equals bd.IdXe
                         join bh in lstXeBaoHiem on xe.ID equals bh.IdXe
                         join lx in lstLoaiXe on xe.IdLoaiXe equals lx.Id
                         join hx in lstHangXe on lx.IdHangXe equals hx.Id

                         select xe;
            return result.ToList();
        }
        public List<KhachHang> GetKhachHang(string name)
        {
            return khachHangRepo.GetALL().Where(p=>p.Name.Contains(name)).ToList();
        }

    }
}