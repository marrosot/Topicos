using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Topicos.MiLogicaDeNegocio
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ILogicaNegocio
    {
        [OperationContract]
        ResultadoEcuacionCuadratica ResolverEcuacionCuadratica(float a, float b, float c);

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here
    }

    [DataContract]
    public class ResultadoEcuacionCuadratica
    {
        private double elDiscriminante;

        [DataMember]
        public double Discriminante
        {
            get { return elDiscriminante; }
            set { elDiscriminante = value; }
        }

        private double? laPrimeraRaiz;

        [DataMember]
        public double? PrimeraRaiz
        {
            get { return laPrimeraRaiz; }
            set { laPrimeraRaiz = value; }
        }

        private double? laSegundaRaiz;

        [DataMember]
        public double? SegundaRaiz
        {
            get { return laSegundaRaiz; }
            set { laSegundaRaiz = value; }
        }




    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
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
