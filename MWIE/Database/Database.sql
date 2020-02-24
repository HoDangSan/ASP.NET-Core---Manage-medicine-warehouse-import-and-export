USE MWIE

INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc gây mê', 2);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc trị đau nhức và chăm sóc giảm nhẹ', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc chống dị ứng và phản vệ', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc giải độc và các chất giải độc khác', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc chống co giật', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc chống bệnh truyền nhiễm', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc chữa bệnh đau nửa đầu', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc chống khối u và ức chế miễn dịch', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc chống bệnh Parkinson', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc ảnh hưởng đến máu', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc tim mạch', 1);
INSERT INTO GroupDrugs(Name,IsActive) VALUES (N'Thuốc da liễu (bôi trên da)', 1);
INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP TRAPHACO ',N'09 Trương Thị Minh Khai, Q.1, Tân Bình, TP.HCM',N'0122374747',N'DonngA@gmail.com', 1);
INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP Dược Hậu Giang ',N'09 Trương Thị Minh Khai, Q.1, Tân Bình, TP.HCM',N'0122374747',N'HauGiang@gmail.com', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP PYMEPHARCO ',N' 03 Nguyễn Trường Tộ, Q.1, Tân Bình, TP.HCM',N'0122374747',N'Pymehaco@gmail.com', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP Xuất Nhập Khẩu Y Tế DOMESCO ',N'09 Nguyễn Ðình Chiểu, Q.1, Tân Bình, TP.HCM',N'0122374747',N'DomeSco@gmail.com', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP Dược Phẩm TIMEXPHARM ',N'09 Trần Hưng Ðạo,  TP.HCM',N'0122374747',N'DuocTimePham@gmail.com', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP Dược Trang Thiết Bị Y Tế Bình Định',N'09 Nguyễn Huệ,  TP.HCM',N'0122374747',N'BinhDinh@gmail.com', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP Dược Phẩm Hà Tây ',N'09 Nguyễn Văn Bảo, , TP.HCM',N'0122374747',N'DuocHatay@gmai.com', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP Dược Phẩm OPC',N'09 Phổ Quang,  TP.HCM',N'0122374747',N'', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty CP Hóa-Dược Phẩm MEKOPHAR',N'09 Đặng Dung, TP.HCM',N'0122374747',N'', 1);

INSERT INTO Producers(Name,Address,Phone,Email,IsActive) VALUES (N'Công Ty ',N'09 Trương Thị Minh Khai, Q.1, Tân Bình, TP.HCM',N'0122374747',N'', 1);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'A.T Etoposide inj 100mg/5ml',N'lọ',N'4',N'100.000',N'09/06/2016',N'09/06/2020',1,1,10);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Aceronko 4mg ',N'Viên',N'3',N'500.000',N'09/06/2016',N'09/06/2020',1,1,9);	
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Acid Folic 5mg  ',N'Viên',N'6',N'900.000',N'09/06/2016',N'09/06/2020',1,1,9);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Actrapid 100 IU/ml  ',N'Lọ',N'6',N'900.000',N'09/06/2016',N'09/06/2020',1,2,8);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Acyclovir 250mg   ',N'Lọ',N'7',N'900.000',N'09/06/2016',N'09/06/2020',1,2,8);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Acyclovir Stada 800mg   ',N'Lọ',N'7',N'27.000',N'09/06/2016',N'09/06/2020',1,2,8);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Adalat LA 30mg ',N'Viên',N'7',N'28.000',N'06/06/2016',N'09/06/2020',1,3,7);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Adrenalin 1mg  ',N'Ống',N'6',N'29.000',N'05/07/2016',N'09/06/2020',1,3,7);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Adrenaline-BFS 1mg/1ml [Epinephrin  ',N'Ống',N'9',N'89.000',N'05/07/2016',N'09/06/2020',1,3,7);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Agifuros 40mg',N'Viên',N'90',N'89.000',N'05/07/2016',N'09/06/2020',1,4,6);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Airway',N'Cái',N'90',N'89.000',N'05/07/2016',N'09/06/2020',1,4,6);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Aldactone 25mg ',N'Viên',N'90',N'8.000',N'05/07/2016',N'09/06/2020',1,4,6);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Alkeran 50mg  ',N'Lọ',N'90',N'89.000',N'05/07/2016',N'09/06/2020',1,6,5);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Ampicicilline 1g ',N'Lọ',N'90',N'8.000',N'05/07/2016',N'09/06/2020',1,6,5);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Angut 300mg ',N'VIên',N'100',N'8.000',N'05/07/2016',N'09/06/2020',1,6,5);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Angut 300mg  ',N'VIên',N'100',N'8.000',N'05/07/2016',N'09/07/2020',1,7,4);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Aspirin 81 81mg  ',N'Lọ',N'10',N'8.000',N'05/07/2016',N'09/07/2020',1,7,4);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Atifolin inj 50mg/5ml  ',N'Lọ',N'10',N'8.000',N'05/07/2016',N'09/07/2020',1,7,4);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Atifolin inj 50mg/5ml  ',N'Lọ',N'10',N'8.000',N'05/07/2016',N'09/07/2020',1,5,3);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Atropin sulfat 0,25mg   ',N'Ống',N'10',N'8.000',N'05/07/2016',N'09/07/2020',1,5,3);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Avelox 400mg/250ml  ',N'Ống',N'10',N'8.000',N'05/07/2016',N'09/07/2020',1,5,3);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Baraclude 0,5mg',N'Viên',N'10',N'9.000',N'08/07/2016',N'09/07/2020',1,8,11);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Bicebid 200mg',N'Viên',N'10',N'19.000',N'08/07/2016',N'09/07/2020',1,8,11);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Calci clorid 500mg/5ml',N'Ống',N'50',N'19.000',N'08/07/2016',N'09/07/2020',1,8,11);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Calci clorid 500mg/5ml',N'Ống',N'50',N'19.000',N'08/07/2016',N'09/07/2020',1,9,2);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Calcium Folinat 100mg Injection 10mg/ml',N'Lọ',N'5',N'19.000',N'08/07/2016',N'09/07/2020',1,9,2);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Folinic 100mg Injection 10mg/ml',N'Lọ',N'5',N'49.000',N'08/07/2016',N'09/07/2020',1,9,2);

INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Cammic 500mg',N'Lọ',N'5',N'49.000',N'08/07/2016',N'09/07/2020',1,4,1);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Captopril 25mg',N'Viên',N'5',N'69.000',N'08/07/2016',N'09/07/2020',1,5,1);
INSERT INTO Drugs(Name,Unit,Amount,Price,DateOfManufacture,ExpriryDate,IsActive,ProducerId,GroupDrugId) VALUES (N'Cavafix Certo G14 8cm',N'Cái',N'5',N'79.000',N'08/07/2016',N'03/07/2020',1,7,1);


