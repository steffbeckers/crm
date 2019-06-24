export interface Account {
  Id: string;
  Name: string;
  Email: string;
  Telephone: string;
  Fax: string;
  Website: string;
  VATNumber: string;
  Description: string;
  AddressId: string;
  ParentAccountId: string;
  BillingAccountId: string;
  RelationTypeId: string;
  PrimaryContactId: string;
  CreatedOn: string;
  ModifiedOn: string;
  DeletedOn: string;
  CreatedById: string;
  ModifiedById: string;
}

export interface AccountRelationType {
  Id: string;
  Name: string;
  DisplayName: string;
}

export interface Address {
  Id: string;
  Street: string;
  Number: string;
  City: string;
  State: string;
  PostalCode: string;
  Latitude: number;
  Longitude: number;
  CountryId: string;
  CreatedOn: string;
  ModifiedOn: string;
  DeletedOn: string;
  CreatedById: string;
  ModifiedById: string;
}

export interface Contact {
  Id: string;
  FirstName: string;
  LastName: string;
  JobTitle: string;
  Email: string;
  Telephone: string;
  MobilePhone: string;
  Gender: number;
  AccountId: string;
  CreatedOn: string;
  ModifiedOn: string;
  DeletedOn: string;
  CreatedById: string;
  ModifiedById: string;
}

export interface Country {
  Id: string;
  Name: string;
  NativeName: string;
  Alpha2Code: string;
  Alpha3Code: string;
  Capital: string;
  Region: string;
  Subregion: string;
  NumericCode: string;
  Flag: string;
}

export interface Role {
  Id: string;
  Name: string;
  NormalizedName: string;
  ConcurrencyStamp: string;
}

export interface User {
  Id: string;
  UserName: string;
  NormalizedUserName: string;
  Email: string;
  NormalizedEmail: string;
  EmailConfirmed: boolean;
  PasswordHash: string;
  SecurityStamp: string;
  ConcurrencyStamp: string;
  PhoneNumber: string;
  PhoneNumberConfirmed: boolean;
  TwoFactorEnabled: boolean;
  LockoutEnd: string;
  LockoutEnabled: boolean;
  AccessFailedCount: number;
  FirstName: string;
  LastName: string;
}

export interface UserRole {
  UserId: string;
  RoleId: string;
}
