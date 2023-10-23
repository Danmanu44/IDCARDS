

//alert("hhhhhhhhhhh");
console.log("######################")


function createAlert(obj) {

    var student = JSON.parse(obj);
    alert(obj + obj.length);
    //console.log(student)
    for (var i = 0; i < student.length; i++) {

        console.log(student[i].FirstName);

    }

}




    ///new trial
    //var divContents = document.querySelector("#con").cloneNode(true);
    //var printWindow = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    //printWindow.document.write('<html><head><title>DIV Contents</title>');
    //printWindow.document.write('</head><body >');
    //printWindow.document.write(divContents);
    //printWindow.document.write('</body></html>');
    //printWindow.document.close();
    //printWindow.print();


function generateTemplate(jsonobj) {
    var studentlist = JSON.parse(jsonobj);
    const app = document.querySelector('#app');
    app.style.display = "block";
    var htmltemp = `${studentlist.map(function (student) {

        return `
<div class="idtemplate">
    <div style="width:100%;"> <span class="c"><img src="/gsulogo.jfif" asp-append-version="true" style="width:20%;height:40px; flow-from:initial;"/></span> <span class="b">GOMBE STATE UNIVERSITY<br><span class="centerparent" id="subtitle">P.M.B 127,GOMBE NIGERIA</span> </span></div>
  <div>
       <img class="passport centerparent"  src="/PassPort_hafiz.jpg" asp-append-version="true" width=100 />
   </div>
<div class="centerparent" id="fullName">
      ${student.FirstName} ${student.LastName}
   </div>
<div class="centerparent" id="fullName">
      ${student.FirstName} ${student.LastName}
   </div>
</div>

                `

    }).join('')}
`

    //    <div style="width:100%;"> <span class="c"><img src="/gsulogo.jfif" asp-append-version="true" style="width:20%;height:40px; flow-from:initial;"/></span> <span class="b">GOMBE STATE UNIVERSITY<br><span class="centerparent" id="subtitle">P.M.B 127,GOMBE NIGERIA</span> </span></div>

    app.innerHTML = `
    ${studentlist.map(function (student) {

        var qrcodjs = new QRCode("qrcode", {
            text: student.RegNumber,
            width: 128,
            height: 128,
            colorDark: "#000000",
            colorLight: "#ffffff",
            correctLevel: QRCode.CorrectLevel.H
        });


        return `
<div class="idtemplate">
  <div>
       <img class="passport centerparent"  src="/PassPort_hafiz.jpg" asp-append-version="true" width=100 />
   </div>
<div class="centerparent" id="fullName">
      ${student.FirstName} ${student.LastName}
   </div>
<div class="centerparent" id="fullName">
      ${student.FirstName} ${student.LastName}
   </div>
</div>

 <div class="html2pdf__page-break"></div>
 <div  class="back" style="background-image:url('../images/STD BCK.jpg');height: 202px;width: 325px; display: block; background-repeat:no-repeat; background-size: 325px 205px;" id="back">
           <p id="qr" style="position:relative; left:257px; top:145px;" ><img style="width:70px" src="${qrcodjs._oDrawing._elCanvas.toDataURL("image/png")}"/> </p>

        </div>



 <div class="html2pdf__page-break"></div>

                `

    }).join('')}
`
    //var printWindow = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    //printWindow.document.write('<html><head><title>DIV Contents</title>');
    //printWindow.document.write('</head><body >');
    //printWindow.document.write(htmltemp);
    //printWindow.document.write('</body></html>');
    //printWindow.document.close();
    //printWindow.print();


    //var doc = new jsPDF();
    //var elementHTML = $('#content').html();
    //var specialElementHandlers = {
    //    '#elementH': function (element, renderer) {
    //        return true;
    //    }
    //};
    //doc.fromHTML(htmltemp, 15, 15, {
        
    //    'width': auto,
    //    'elementHandlers': specialElementHandlers
    //});
    //doc.fromHTML

    //// Save the PDF
    //doc.save('sample-document.pdf');

    var opt = {
        margin: 0,
        filename: 'myfile.pdf',
        image: { type: 'jpeg', quality: 0.98 },
        pagebreak: { before: '.beforeClass', after: ['#last', '#after2'], avoid: 'img' },
        jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
    };
    var element = htmltemp;
    html2pdf(element, {
        margin: 10,
        filename: 'myfile.pdf',
        image: { type: 'jpeg', quality: 0.98 },
        html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },
        jsPDF: { unit: 'mm', format: 'a4', orientation: 'portrait' }

    });
    //html2pdf(element);
    //var worker = html2pdf();  // Or:  var worker = new html2pdf.Worker;
    //worker = html2pdf().set(opt).from(element).save();



}


function blankAvoid(studentArray) {
    var studentlist = JSON.parse(studentArray);

    var pages = document.getElementById('temp')
    const exportHTMLToPDF = async (pages, outputType = 'blob') => {
        console.log('checking now the pdf');
        const opt = {
            margin: [0, 0],
            filename: 'myfile.pdf',
            image: { type: 'jpeg', quality: 0.98 },
            html2canvas: { dpi: 192, letterRendering: true },
            jsPDF: { unit: 'mm', format: 'credit-card', orientation: 'landscape' }
        };
        const doc = new jsPDF(opt.jsPDF);
        const pageSize = jsPDF.getPageSize(opt.jsPDF);
        for (let i = 0; i < pages.length; i++) {
            const page = pages[i];
            const pageImage = await html2pdf().from(page).set(opt).outputImg();
            if (i != 0) {
                doc.addPage();
            }
            doc.addImage(pageImage.src, 'jpeg', opt.margin[0], opt.margin[1], pageSize.width, pageSize.height);
        }
        // This can be whatever output you want. I prefer blob.
        const pdf = doc.output(outputType);
        return pdf;
    }
}

var pages = document.getElementById("temp");

//const ExportToPdf = async(pages,outputType='blob')=> {
//    console.log("checking pdf now..");
//    const opt = {
//        margin: [0, 0],
//        filename: 'myfile.pdf',
//        image: { type: 'jpeg', quality: 0.98 },
//        html2canvas: { dpi: 192, letterRendering: true },
//        jsPDF: { unit: 'in', format: 'letter', orientation: 'portrait' }
//    };
//    const doc = new jsPDF(opt.jsPDF);
//    const pageSize = jsPDF.getPageSize(opt.jsPDF);
//    for (let i = 0; i < pages.length; i++) {
//        const page = pages[i];
//        const pageImage = await html2pdf().from(page).set(opt).outputImg();
//        if (i != 0) {
//            doc.addPage();
//        }
//        doc.addImage(pageImage.src, 'jpeg', opt.margin[0], opt.margin[1], pageSize.width, pageSize.height);
//    }
//    // This can be whatever output you want. I prefer blob. 
//    const pdf = doc.output(outputType);
//    return pdf;

//}



async function testpdf(studentArray) {

    var studentlist = JSON.parse(studentArray);
  
    var elem = `
    ${studentlist.map(function (student) {
        var qrcodjs = new QRCode("qrcode", {
            text: student.RegNumber,
            width: 128,
            height: 128,
            colorDark: "#000000",
            colorLight: "#ffffff",
            correctLevel: QRCode.CorrectLevel.H
        });

        

        return `





<div  class="centerparent" style="height:200px" >


    <div id="containe" style="width:100%;">
  <div id="left" style="float:left; width:68%;height:100%;  ">  <div id="fullName" class="grid-item">
   <p class="labels" id="fullName"> ${student.LastName} <span style="font-size:8pt">  ${student.FirstName}  ${student.MiddleName}</span></p>

    </div>
    <div id="regNo" class="grid-item">
   <p class="labels" id="regNumber"> ${student.RegNumber} </p>

    </div>

    <div id="department" class="grid-item">
           <p class="labels" id="department"> ${student.Department} </p>
            
    </div>

    <div id="nextOfKin" class="grid-item">
            <p class="labels" id="nextOfKin"> ${student.NextOfKinPhone} </p>

    </div> </div>
  <div id="right" style="float:right; width:32%; ">

  <img  src=${"/images/" + student.RegNumber + ".jpg"} style="position:relative;left:15px;top:45px;border:solid 1px black;border-radius:10px; width:90px;height:100px"  alt="error"  id=""/>

</div>
   </div>
     

</div>

 <div class="html2pdf__page-break"></div>
<div  class="back"  id="back">
           <p class="image" id="qr" style="position:relative; left:257px; top:140px;" > <img style="width:50px; height:50px" src="${qrcodjs._oDrawing._elCanvas.toDataURL("image/png")}"/>
</p>

        </div>



 <div class="html2pdf__page-break"></div>

                 `


    }).join('')}
`
    var app = document.getElementById("temp");
   // app.innerHTML = elem;
    var counter = 0;
    var divContainer = document.createElement("div")
    divContainer.style.margin="0px"
    var element= app
    html2pdf(element, {

        margin: 0,
        filename: 'myfile.pdf',
        image: { type: 'jpeg', quality: 1.98 },
        html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },

        jsPDF: { unit: 'mm', format: 'credit-card', orientation: 'landscape' }
    });

    //The below code is working as expected 
    //var element = app[i];
    //html2pdf(element, {
         
    //    margin: 0,
    //    filename: 'myfile.pdf',
    //    image: { type: 'jpeg', quality: 1.98 },
    //    html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },

    //    jsPDF: { unit: 'mm', format: 'credit-card', orientation: 'landscape' }
    //});
}
const download = function (tag) {
    var element = tag;
    html2pdf(element, {

        margin: 0,
        filename: 'myfile.pdf',
        image: { type: 'jpeg', quality: 1.98 },
        html2canvas: { scale: 2, logging: true, dpi: 192, letterRendering: true },

        jsPDF: { unit: 'mm', format: 'credit-card', orientation: 'landscape' }
    });
}

async function GeneratePdf(department) {
    console.log("in function###################");
    console.log(department);
    var parentTag = document.getElementById("temp");
    for (var i = 0; i < parentTag.childElementCount; i++) {
        var element = document.getElementById("batch" + i);
        html2pdf(element, {
            margin: 0,
            filename: department + i + ".pdf",
            image: { type: 'jpeg', quality: 2.0 },
            html2canvas: { scale: 2, logging: true, dpi: 350, letterRendering: true },
            jsPDF: { unit: 'mm', format: 'credit-card', orientation: 'landscape' }
        });
    }

}