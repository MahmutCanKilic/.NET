using tr.gov.tubitak.uekae.esya.api.asn.x509;
using tr.gov.tubitak.uekae.esya.api.cmssignature;
using tr.gov.tubitak.uekae.esya.api.cmssignature.attribute;
using tr.gov.tubitak.uekae.esya.api.cmssignature.signature;
using tr.gov.tubitak.uekae.esya.api.cmssignature.validation;
using tr.gov.tubitak.uekae.esya.api.common.crypto;
using tr.gov.tubitak.uekae.esya.api.smartcard.pkcs11;
using tr.gov.tubitak.uekae.esya.asn.util;

namespace ElectronicSignatureSample
{
    public class Program
    {



        static void Main(string[] args)
        {
            BaseSignedData bs = new BaseSignedData();
            string filePath = @"C:\Users\P2635\Desktop\TestDocument.txt";
            byte[] signature = File.ReadAllBytes(filePath);
            ISignable content = new SignableByteArray(signature);
            bs.addContent(content);

            Dictionary<string, object> params_ = new Dictionary<string, object>();

            params_[EParameters.P_VALIDATE_CERTIFICATE_BEFORE_SIGNING] = false;
            //params_[EParameters.P_CERT_VALIDATION_POLICY] = getPolicy();
            //bool QCStatement = isQualified();

            string cardPin = "123";

            ECertificate cert = SmartCardManager.getInstance().getSignatureCertificate(true);
            BaseSigner signer = SmartCardManager.getInstance().getSigner(cardPin, cert);

            try
            {
                bs.addSigner(ESignatureType.TYPE_BES, cert, signer, null, params_);
            }
            catch (CertificateValidationException cve)
            {

                Console.WriteLine(cve.getCertStatusInfo().getDetailedMessage());
            }

            SmartCardManager.getInstance().logout();

            byte[] signedDocument = bs.getEncoded();
            string newFilePath = @"C:\Users\P2635\Desktop\NewTestDocument.txt";
            File.WriteAllBytes(newFilePath, signedDocument);
            
        }
    }
}