delete from gemsdtat..txcoea
go
INSERT INTO gemsdtat..txcoea SELECT * FROM gemstemp..txcoea
go
delete from gemsdtat..txinv
go
INSERT INTO gemsdtat..txinv SELECT * FROM gemstemp..txinv
go
delete from gemsdtat..txhst
go
INSERT INTO gemsdtat..txhst SELECT * FROM gemstemp..txhst
go
delete from gemsdtat..utcoea
go
INSERT INTO gemsdtat..utcoea SELECT * FROM gemstemp..utcoea
go
delete from gemsdtat..utcust
go
INSERT INTO gemsdtat..utcust SELECT * FROM gemstemp..utcust
go
delete from gemsdtat..utcustas
go
INSERT INTO gemsdtat..utcustas SELECT * FROM gemstemp..utcustas
go
delete from gemsdtat..utcustrt
go
INSERT INTO gemsdtat..utcustrt SELECT * FROM gemstemp..utcustrt
go