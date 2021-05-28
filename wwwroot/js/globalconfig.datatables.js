$.extend(true, $.fn.dataTable.defaults, {
	ordering: false,
	autoWidth: true,
	language: {
		info: "Trang _PAGE_ trên tổng số _PAGES_ (_MAX_)",
		infoFiltered: " (tổng cộng _MAX_ bản ghi)",
		processing: "Đang xử lý...",
		zeroRecords: "Không tìm thấy dữ liệu",
		emptyTable: "Không có dữ liệu",
		infoEmpty: "Không có dữ liệu",
		search: "Tìm kiếm",
		lengthMenu: "Hiển thị _MENU_ dòng",
		paginate: {
			first: "❮❮",
			last: "❯❯",
			next: "❯",
			previous: "❮",
		}
	},
	columnDefs: [
		{
			// Thêm thuộc tính dât-id vào ô cuối của table
			'targets': [-1],	// Cột cuối của table
			'createdCell': function (td, cellData, rowData, row, col) {
				if (rowData.hasOwnProperty("id")) {
					$(td).attr('data-id', rowData.id);
					$(td).attr('update', '');
				}
			}
		}
	]
});