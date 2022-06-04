﻿using ApplicationService.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string GetData(int value);
        [OperationContract]
        void SetCurrentId(int value);
        [OperationContract]
        int GetCurrentId();
        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
        [OperationContract]
        List<BrandDTO> GetBrands(string filter);

        [OperationContract]
        string PostBrand(BrandDTO brandDto);

        [OperationContract]
        string PutBrand(BrandDTO brandDto);

        [OperationContract]
        BrandDTO GetBrandByID(int id);

        [OperationContract]
        string DeleteBrand(int id);

        [OperationContract]
        List<MotorcycleDTO> GetMotorcycles(string filter);

        [OperationContract]
        MotorcycleDTO GetMotorcycleByID(int id);

        [OperationContract]
        string PostMotorcycle(MotorcycleDTO motorcycleDto);

        [OperationContract]
        string PutMotorcycle(MotorcycleDTO motorcycleDto);

        [OperationContract]
        string DeleteMotorcycle(int id);

        [OperationContract]
        List<SaleDTO> GetSales(string filter);

        [OperationContract]
        SaleDTO GetSaleByID(int id);

        [OperationContract]
        string PostSale(SaleDTO saleDto);

        [OperationContract]
        string PutSale(SaleDTO saleDto);

        [OperationContract]
        string DeleteSale(int id);
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "WCFServ.ContractType".
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
