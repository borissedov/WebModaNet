/// <reference path="~/Scripts/jquery-1.4.1-vsdoc.js" />

var WebModa = {
    init: function () {
    }
};

$(document).ready(function () {
    WebModa.init();
});

// conferma sospensione applicazione
$(function () {
    $(".sospensione").click(function () {
        return confirm("Sei sicuro di voler sospendere l'applicazione?");
    });
});

// etichetta file
$(function () {
    $(".file-label").click(function () {
        var fileField = $("#" + $(this).attr("for"));
        fileField.click();
    });
});

// bottoni duplica e  copia/incolla
$(function () {
    // salva l'ultima selezione
    $(".quantity").click(function () {
        window.currentTextBox = $(this)[0];
    });

    // duplica
    $(".duplicate").click(function () {
        var quantityFieldArray = [];
        var quantityToCopy = -1;
        var columns = $(this).parent().nextAll("td");

        // cicla tutte le colonne per trovare i campi delle quantità
        columns.each(function (index, element) {

            var elements = $(".quantity", element);

            if (elements.length > 0) {
                // campo con la quantità
                var field = elements.first();

                // se l'elemento è l'ultimo selezionato allora rimuove i precedenti dalla lista
                if (window.currentTextBox && field[0] == window.currentTextBox) {
                    quantityFieldArray = [];
                    quantityToCopy = -1;
                }

                // imposta la quantità da copiare
                if (quantityToCopy < 0) {
                    var value = parseInt(field.val(), 10);

                    if (!isNaN(value) && value >= 0) {
                        quantityToCopy = value;
                    }
                    else {
                        quantityToCopy = 0;
                    }
                }

                quantityFieldArray.push(field);
            }
        });

        // copia le quantità nelle rispettive caselle
        for (var i = 0; i < quantityFieldArray.length; i++) {
            quantityFieldArray[i].val(quantityToCopy);
        }

        return false;
    });

    // copia
    $(".copy").click(function () {
        var quantities = [];
        var columns = $(this).parent().parent().find(".cellaQuantita");

        columns.each(function (index, element) {
            var quantity = $(".quantity", element);
            if (quantity.length > 0) {
                var value = parseInt(quantity.val(), 10);
                if (!isNaN(value)) {
                    quantities.push(value);
                }
                else {
                    quantities.push(0);
                }
            }
        });

        // salva il valore anche nei cookie
        $.cookie("quantita", quantities);
        $(document).data("quantita", quantities);

        return false;
    });

    // incolla
    $(".paste").click(function () {
        var quantities = $(document).data("quantita");

        if (typeof (quantities) == "undefined") {
            quantities = $.cookie("quantita");

            if (typeof (quantities) == "undefined") {
                return;
            }
            else {
                quantities = $.cookie("quantita").split(',');
            }
        }

        var columnIndex = 0;
        var columns = $(this).parent().parent().find(".cellaQuantita");

        columns.each(function (index, element) {
            var quantity = $(".quantity", element);
            if (quantity.length > 0) {
                if (columnIndex < quantities.length) {
                    quantity.val(quantities[columnIndex]);
                    columnIndex++;
                }
            }
        });

        return false;
    });
});


// autocomplete

function sourceCallback(request, callback) {
    var term = request.term.toString();
    var lowerTerm = term.toLowerCase();

    // prende le option dalla select
    var options = $(".lista-clienti option");
    var values = [];

    options.each(function (index, element) {
        var text = element.text;
        var lowerText = text.toLowerCase();

        // non prende il primo elemento vuoto
        if (index != 0 && lowerText.indexOf(lowerTerm) >= 0) {
            values.push(text);
        }
    });

    callback(values);
}

function selectCallback(event, ui) {
    var term = ui.item.value.toString();
    var options = $(".lista-clienti option");
    var selectedIndex = 0;

    options.each(function (index, element) {
        var text = element.text;

        if (text === term) {
            $(".textbox-clienti").val("");
            $(".lista-clienti").attr("selectedIndex", index);
            $(".lista-clienti").change();
            return false;
        }
    });
}

$(function () {
    $(".textbox-clienti").autocomplete({
        source: sourceCallback,
        select: selectCallback
    });
});


// autocomplete agenti
$(function () {
    $(".codiceUtente").autocomplete({
        source: "AgentiHandler.ashx",
        close: agentiCloseCallback
    });
});

function agentiCloseCallback(event, ui) {
    $("[id$='CercaButton']").click();
}

// autocomplete articoli

function articoliSourceCallback(request, callback) {
    var term = request.term.toString();
    var lowerTerm = term.toLowerCase();

    // prende le option dalla select
    var options = $(".listaArticoli option");
    var values = [];

    options.each(function (index, element) {
        var value = element.value;
        var text = element.text;
        var lowerText = text.toLowerCase();

        // non prende il primo elemento vuoto
        if (lowerText.indexOf(lowerTerm) >= 0) {
            values.push({ value: value, label: text });
        }
    });

    callback(values);
}

function articoliSelectCallbackByOptions(event, ui) {
    var term = ui.item.value.toString();
    var options = $(".listaArticoli option");
    var selectedIndex = 0;

    options.each(function (index, element) {
        var value = element.value;

        if (value === term) {
            $(".listaArticoli").attr("selectedIndex", index);
            $(".listaArticoli").change();
            return false;
        }
    });
}



function articoliSelectCallbackByHandler(event, ui) {

    $(".cercaPerCodice").click();
}

$(function () {
    if (window.isModificaOrdine) {
        if (webModaRelease == "Giesse")
        {
            $(".codiceArticolo").autocomplete({
                source: articoliSourceCallback,
                select: articoliSelectCallbackByOptions
            });
        }
        else
        {
            $(".codiceArticolo").autocomplete({
                minLength: 3,
                source: "ArticoliHandler.ashx",
                close: articoliSelectCallbackByHandler
            });
        }
    }
});

// datepicker

$(function () {
    $(".date").datepicker($.datepicker.regional["it"]);
    $(".date").datepicker({
        dateFormat: "dd-mm-yy"
    });
    // impedisce all'utente di digitare una data manualmente
    $(".date").keypress(function () {
        //return false;
    });
});

// nyroModal
$(function () {
    var listaArticoli = $(".listaArticoli");
    var options = $(".listaArticoli option");

    $(".nyroModal").each(function (index, element) {
        var codiceArticolo = $(this).data("codiceArticolo").toString();
        var lowerCodiceArticolo = codiceArticolo.toLowerCase();
        $(element).data("lowerCodiceArticolo", lowerCodiceArticolo);

        $(this).nyroModal({
            callbacks: {
                afterClose: function (obj) {
                    var lowerCodiceArticolo = obj.opener.data("lowerCodiceArticolo");
                    var selectIndex = 0;

                    // prende l'elemento selezionato
                    options.each(function (index, element) {
                        var value = element.value;
                        var lowerValue = value.toLowerCase();

                        if (lowerValue == lowerCodiceArticolo) {
                            selectIndex = index;
                        }
                    });

                    listaArticoli.attr("selectedIndex", selectIndex);
                    listaArticoli.change();
                }
            }
        });
    });
});

// autoselect
$(function () {
    $(".autoselect").click(function () {
        $(this).select();
    });
});


$(function () {
    $(".quantity").click(function () {
        $(this).select();
    });
});

// quantità onblur
/*$(function () {
    $(".quantity").blur(function () {
        var quantityField = $(this);

        // quantità inserita
        var quantity = parseInt(quantityField.val(), 10);

        if (isNaN(quantity)) {
            quantity = 0;
        }

        // quantità pack
        var pack = parseInt(element.nextAll(".pack").val(), 10);

        if (isNaN(pack)) {
            pack = 1;
        }

        // controlla se la quantità è un multiplo del pack
        if (quantity > 0 && quantity % pack != 0) {
            quantity
        }

        $(this).val(quantity.toString());
    });
});*/

// bottoni "+" e "-" per le quantità
$(document).ready(function () {
    $(".add").click(function () {
        changeQuantity($(this), true);
    });
    $(".subtract").click(function () {
        changeQuantity($(this), false);
    });
});

function changeQuantity(element, add) {

    // step per l'incremento/decremento
    var step = parseInt(element.prevAll(".pack").val(), 10);

    if (isNaN(step)) {
        step = 1;
    }

    // quantità massima
    var max = parseInt(element.prevAll(".max").val(), 10);

    if (isNaN(max)) {
        max = 9999;
    }

    // quantità inserita
    //var value = parseInt(element.prevAll(".quantity").val(), 10);
    var quantityTextBox = element.parent().parent().find(".inputQuantita").find(".quantity");
    var value = parseInt(quantityTextBox.val(), 10);
    
    if (isNaN(value)) {
        value = 0;
    }

    // effettua l'incremento/decremento
    if (add) {
        if (value + step <= max) {
            for (var i = value + 1; i <= max; i++) {
                if (i % step == 0) {
                    value = i;
                    break;
                }
            }
        }
        else {
            if (max % step == 0) {
                value = max;
            }
            else {
                for (var i = max; i >= step; i--) {
                    if (i % step == 0) {
                        value = i;
                        break;
                    }
                }
            }
        }
    }
    else {
        if (value - step >= 0) {
            for (var i = value - 1; i >= 0; i--) {
                if (i % step == 0) {
                    value = i;
                    break;
                }
            }
        }
        else {
            value = 0;
        }
    }

    // imposta il nuovo valore
    quantityTextBox.val(value);
}


/*
 * Quantità degli imballi
 */

$(document).ready(function () {
    $(".quantitaImballo").blur(function () {
        impostaQuantitaTaglieImballo($(this));
    });

    $(".addImballo").click(function () {
        var quantitaImballoField = $(this).prevAll(".quantitaImballo");
        impostaQuantitaImballo(quantitaImballoField, true);
        impostaQuantitaTaglieImballo(quantitaImballoField);
    });
    $(".subtractImballo").click(function () {
        var quantitaImballoField = $(this).prevAll(".quantitaImballo");
        impostaQuantitaImballo(quantitaImballoField, false);
        impostaQuantitaTaglieImballo(quantitaImballoField);
    });

//Per tendina imballi, non usato
//    $(".dropDownListImballi").change(function() {
//        var sviluppoImballo = $(this).val();
//        var hd = $(this).parent().next("td").find(":hidden");
//        hd.val(sviluppoImballo);
//        var txt = $(this).parent().next("td").find(".quantitaImballo");
//        impostaQuantitaTaglieImballo(txt);
//    });

});

function impostaQuantitaImballo(element, add) {
    var quantitaImballo = parseInt(element.val());

    if (isNaN(quantitaImballo)) {
        quantitaImballo = 0;
    }

    if (add) {
        quantitaImballo++;
    }
    else {
        quantitaImballo--;
    }

    if (quantitaImballo < 0) {
        quantitaImballo = 0;
    }

    element.val(quantitaImballo);
}

function impostaQuantitaTaglieImballo(element) {

    // quantità inserita per l'imballo
    var quantitaImballo = parseInt(element.val(), 10);

    if (isNaN(quantitaImballo)) {
        quantitaImballo = 1;
    }

    // sviluppo
    var sviluppoImballo = element.nextAll(":hidden").val().split("-");

    // array delle quantità per taglia
    var quantitaArray = element.parent().parent().find(".quantity");

    // imposta le nuove quantità
    for (var i = 0; i < sviluppoImballo.length && i < quantitaArray.length; i++) {
        quantitaArray.eq(i).val(quantitaImballo * sviluppoImballo[i]);
    }
}
















/*
$(function () {
    $(".immagineArticolo").draggable({ helper: "clone", revert: true });

    $( ".selector" ).droppable({
       drop: function(event, ui) { ... }
    });
});
*/

function filtriHandler(event) {
    // salva un riferimento al link
    var link = $(this);

    $(".filtriRicerca").toggle("slow", function () {
        // "clicca" il bottone
        location.href = link.attr("href");
    });

    return false;
}

// filtri ricerca
$(function () {
    $(".nascondiFiltri").bind("click", filtriHandler);
    $(".mostraFiltri").bind("click", filtriHandler);
});

// fixed header
$(document).ready(function () {
    if (!window.isModificaOrdine) return;
    fixTableHeader();
    $(window).scroll(function() {
        if (!window.isResizing) {
            $(window).resize();
            window.isResizing = true;
            setTimeout(function() {
                window.isResizing = false;
            }, 5000);
        }
    });
});

function fixTableHeader() {
    $(".fixedHeader").fixedtableheader();
}

// tabs
$(function () {
    var href = location.href;

    if (href.indexOf("ModificaOrdine.aspx") > 0) {
        // niente cookie nella tabella dell'ordine
        $("#tabs").tabs();
    }
    else {
        $("#tabs").tabs({
            cookie: { name: location.href }
        });
    }
});

// imposta la larghezza della galleria
$(function () {
    var galleryList = $(".immaginiPanel ul");
    var totalWidth = 0;

    $(".immaginiPanel li").each(function () {
        totalWidth += $(this).outerWidth(true);
    });

    totalWidth += 10;
    galleryList.width(totalWidth);
});

// scroll a sinistra della gallery
$(function () {
    var gallery = $(".immaginiPanel");
    var selectedElement = $(".immaginiPanel .selected");

    if (selectedElement.length > 0) {
        var galleryLeft = gallery.offset().left;
        var selectedElementLeft = selectedElement.offset().left;
        var offset = selectedElementLeft - galleryLeft;
        offset = offset - 10; // aggiunge il padding a sinistra
        gallery.animate({ scrollLeft: offset }, "slow");
    }
});

// messaggi di conferma
$(function () {
    $(".confirm").live("click", function () {
        return confirm($(this).data("message"));
    });
});

// conferma salvataggio cliente
$(function () {
    $(".salva-cliente").click(function () {
        if (typeof (Page_ClientValidate) == "function") {
            if (Page_ClientValidate("InserisciCliente")) {
                return confirm($(this).data("message"));
            }
        }
    });
});

// validazione dei controlli
$(function () {
    if (typeof (ValidatorUpdateDisplay) != "function") {
        return;
    }

    // salva la funzione di validazione originale
    var originalValidatorUpdateDisplay = ValidatorUpdateDisplay;

    ValidatorUpdateDisplay = function (val) {

        // richiama la funzione per la validazione originale
        originalValidatorUpdateDisplay(val);

        if (!val.controltovalidate) {
            return;
        }

        var controlId = val.controltovalidate;
        var selector = "#" + controlId;

        if (val.isvalid) {
            $(selector).removeClass("inputError");
        }
        else {
            $(selector).addClass("inputError");
        }
    }
});

// seleziona la prima quantità disponibile oppure lo spazio per il codice a barre
$(function () {
    var elements = $(".quantity");

    if (elements.length > 0) {
        elements.first().select();
    }
    else {
        var codiceArticolo = $(".codiceArticolo");

        if (codiceArticolo.length > 0) {
            codiceArticolo.first().select();
        }
    }
});

// seleziona tutti gli agenti
$(function () {
    $(".selezionaTuttiAgenti").click(function () {
        $(".selezionaAgente input").attr("checked", $(this).attr("checked"));
    });
});

// controllo integrità
$(function () {
    $(".confermaQuantita").click(function (event) {
        var message = $(this).data("confirm");

        // cicla tutte le righe
        $(".tabellaQuantita tr").each(function (index, element) {
            var qtyList = $(".quantity", element);

            if (qtyList.length > 0) {
                var min = 999999;
                var max = 0;

                // cicla tutte le singole quantità
                qtyList.each(function (innerIndex, innerElem) {
                    var value = parseInt($(innerElem).val());

                    if (!isNaN(value) && value > 0) {
                        if (value < min) {
                            min = value;
                        }
                        if (value > max) {
                            max = value;
                        }
                    }
                });

                if (min > 0) {
                    //alert("max " + max + ", min " + min + " , " + (max/min) );

                    if (max / min > 10) {
                        
                        if (!confirm(message)) {
                            event.preventDefault();
                        }
                        return;
                    }
                }
            }
        });
    });
});

//
// Gestione degli imballi

$(function () {
    if (!window.isModificaOrdine) return;
    $(".imballiButton").attr("target", "_blank").nyroModal();
});

//
// Gestione tooltip

$(function () {
    if (!window.isModificaOrdine) return;

    $(".codiceImballo").qtip({
        style: {
            name: "blue",
            tip: "topMiddle",
            border: {
                radius: 5,
                //color: '#A2D959'
            }
        },
        position: {
            corner: {
                target: "bottomMiddle",
                tooltip: "topMiddle"
            }
        }
    });
});

//
// Gestione tooltip in galleria immagine

$(function () {
    if (!window.isModificaOrdine) return;

    $(".ArticoloImage").qtip({
        style: {
            name: "blue",
            tip: "topMiddle",
            border: {
                radius: 5,
                //color: '#A2D959'
            }
        },
        position: {
            corner: {
                target: "bottomMiddle",
                tooltip: "topMiddle"
            }
        }
    });
});

//
// Nasconde gli sconti

$(function () {
    if (!window.nascondiSconto) return;
    $(".colonnaSconto").hide();
});
