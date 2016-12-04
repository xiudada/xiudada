angular.module('realNext.service.sharedModule').constant('PermissionNameConstrant', {

	// "Don't have permission controller"
	Open: 'Open',

	// Dashboard permission start
	ViewNumberOfItems: "brokermanager:dashboad:view:numberOfItems",
	// Dashboard permission end

	// realNext object permission start
	ViewAllRealEstateObjects: "brokermanager:realEstateObjects:realEstateObject:view:all",
	CreateRealEstateObject: "brokermanager:realEstateObjects:realEstateObject:create",
	EditRealEstateObject: "brokermanager:realEstateObjects:realEstateObject:edit",
	DeleteRealEstateObject: "brokermanager:realEstateObjects:realEstateObject:delete",
	ArchiveRealEstateObject: "brokermanager:realEstateObjects:realEstateObject:archive",
	UnArchiveRealEstateObject: "brokermanager:realEstateObjects:realEstateObject:unArchive",
	LinkedOfferInviteBroker: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:inviteBroker",
	LinkedOfferAcceptInvitation: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:acceptInvitation",
	LinkedOfferRejectInvitation: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:rejectInvitation",
	LinkedOfferUpdateInvitation: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:updateInvitation",
	LinkedOfferViewAllInvites: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:invites:view:all",
	LinkedOfferViewInvite: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:invites:view:detail",
	LinkedOfferViewAllMyInvitations: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:myInvitations:view:all",
	LinkedOfferViewMyInvitation: "brokermanager:realEstateObjects:realEstateObject:linkedOffer:myInvitations:view:detail",
	ReportRealnextObjectTransaction: "brokermanager:realEstateObjects:realEstateObject:reportTransaction",
	ViewRecentAddObjects: "brokermanager:realEstateObjects:realEstateObject:view:recentAddObjects",
    ViewGoogleAnalytisc:"brokermanager:realEstateObjects:realEstateObject:google:analytics:view",
	//realNext object permission end

	// User permission start 
	ViewAllUsers: "brokermanager:users:user:view:all",
	CreateUser: "brokermanager:users:user:create",
	EditUser: "brokermanager:users:user:edit",
	DeleteUser: "brokermanager:users:user:delete",
	UserEditLeadReportSetting: "brokermanager:leads:lead:userLeadReportSetting:edit",
	UserEditMultipleLeadReportSetting: "brokermanager:leads:lead:userLeadReportSetting:bulkEdit",
	UserDeleteLeadReportSetting: "brokermanager:leads:lead:userLeadReportSetting:delete",
	// User permission end 

	// Roles permission start
	ViewAllRoles: "brokermanager:roles:role:view:all",
	CreateRole: "brokermanager:roles:role:create",
	EditRole: "brokermanager:roles:role:edit",
	DeleteRole: "brokermanager:roles:role:delete",
	// Roles permission end

	//Transactions start 
	ViewAllTransactions: "brokermanager:transactions:transaction:view:all",
	CreateTransaction: "brokermanager:transactions:transaction:create",
	EditTransaction: "brokermanager:transactions:transaction:edit",
	DeleteTransaction: "brokermanager:transactions:transaction:delete",
	ViewRecentTransactions: "brokermanager:transactions:transaction:view:recentTransactions",
	// Transactions end

	//FinancialTransactions start
	ViewAllFinancialTransactions: "brokermanager:financialTransactions:financialTransaction:view:all",
	ViewFinancialTransaction: "brokermanager:financialTransactions:financialTransaction:view:detail",
	ExportFinancialTransaction: "brokermanager:financialTransactions:financialTransaction:export",
	//FinancialTransactions end

	//dataCollectiveLeads start
	ViewAllLeads: "brokermanager:leads:lead:view:all",
    ViewLead: "brokermanager:leads:lead:view:detail",
    ExportLeads: "brokermanager:leads:lead:export",
	//dataCollectiveLeads end

	//DataMigrations start
	ViewAllDataMigrations: "brokermanager:dataMigrations:dataMigration:view:all",
	CreateDataMigration: "brokermanager:dataMigrations:dataMigration:create",
	//DataMigrations end

	//Settings start
	EditSearchEngineSetting: "brokermanager:settings:searchEngine:edit",
	EditMyLeadReportSetting: "brokermanager:leads:lead:myleadReportSetting:edit",
	ClearMyLeadReportSetting: "brokermanager:leads:lead:myLeadReportSetting:clear",
	//Settings end
});