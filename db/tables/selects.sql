/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [parameterTypeID]
      ,[name]
  FROM [searchfight].[dbo].[parameterTypes]
  
  
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [searchEngineID]
      ,[name]
      ,[description]
      ,[httpMethod]
      ,[httpUrl]
      ,[httpBody]
      ,[beginSection]
      ,[endSection]
      ,[replaceOldValue]
      ,[replaceNewValue]
      ,[patternRegexpExtract]
  FROM [searchfight].[dbo].[searchEngines]
  
  
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [parameterID]
      ,[searchEngineID]
      ,[parameterTypeID]
      ,[name]
      ,[value]
      ,[disabled]
  FROM [searchfight].[dbo].[parameters]