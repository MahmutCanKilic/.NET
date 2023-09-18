using System;
using System.Collections.Generic;
using System.IO;
using tr.gov.tubitak.uekae.esya.api.asn.x509;
using tr.gov.tubitak.uekae.esya.api.certificate.validation.policy;
using tr.gov.tubitak.uekae.esya.api.cmssignature;
using tr.gov.tubitak.uekae.esya.api.cmssignature.attribute;
using tr.gov.tubitak.uekae.esya.api.cmssignature.signature;
using tr.gov.tubitak.uekae.esya.api.cmssignature.validation;
using tr.gov.tubitak.uekae.esya.api.common.crypto;
using tr.gov.tubitak.uekae.esya.api.common.util;
using tr.gov.tubitak.uekae.esya.api.signature.util;
using tr.gov.tubitak.uekae.esya.api.smartcard.pkcs11;
using tr.gov.tubitak.uekae.esya.asn.util;

namespace ElectronicSignatureSample
{
    public class Program
    {



        static void Main(string[] args)
        {
            Stream stream = new FileStream(@"C:\Users\P2635\Desktop\E-Imza\New folder\ma3api-signature-2.3.11-dotnet\lisans\lisans.xml", FileMode.OpenOrCreate);
            LicenseUtil.setLicenseXml(stream);
            BaseSignedData bs = new BaseSignedData();
            string filePath = @"C:\Users\P2635\Desktop\TestDocument.txt";
            byte[] signature = File.ReadAllBytes(filePath);
            ISignable content = new SignableByteArray(signature);
            bs.addContent(content);

            Dictionary<string, object> params_ = new Dictionary<string, object>();

            params_[EParameters.P_VALIDATE_CERTIFICATE_BEFORE_SIGNING] = false;

            ValidationPolicy policy = PolicyReader.readValidationPolicy(
                new FileStream(@"C:\Users\P2635\Desktop\E-Imza\New folder\ma3api-signature-2.3.11-dotnet\config\certval-policy.xml", FileMode.Open));
            params_[EParameters.P_CERT_VALIDATION_POLICY] = policy;
            //bool QCStatement = true;


            //string cardPin = "123";

            //ECertificate cert = SmartCardManager.getInstance().getSignatureCertificate(true);
            //BaseSigner signer = SmartCardManager.getInstance().getSigner(cardPin, cert);
            string pfxPath = @"C:\Users\P2635\Desktop\testkurum01@test.com.tr_333165.pfx";
            PfxSigner signer = new PfxSigner(Algorithms.SIGNATURE_RSA_SHA256, pfxPath, "333165");
            
            ECertificate cert = signer.getSignersCertificate();
            try
            {
                bs.addSigner(ESignatureType.TYPE_BES, cert, signer, new List<IAttribute>(), params_);
            }
            catch (CertificateValidationException cve)
            {

                Console.WriteLine(cve.getCertStatusInfo().getDetailedMessage());
            }


            byte[] signedDocument = bs.getEncoded();
            //SmartCardManager.getInstance().logout();


            string newFilePath = @"C:\Users\P2635\Desktop\NewTestDocument.p7s";
            File.WriteAllBytes(newFilePath, signedDocument);

        }
    }
}