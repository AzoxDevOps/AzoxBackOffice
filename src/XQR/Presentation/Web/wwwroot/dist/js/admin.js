window.generateQrCode = function (elementId, qrCodeOptions) {

    let qrCode = new QRCodeStyling(qrCodeOptions),
        element = document.getElementById(elementId);

    qrCode.append(element);
}