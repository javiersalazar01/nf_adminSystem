
var mesos = ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'];

var dias_num = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31];
var dies_abr = ['Sa', 'Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi'];


Number.prototype.pad = function (num) {
     var str = '';
     for (var i = 0; i < (num - this.toString().length) ; i++)
          str += '0';
     return str += this.toString();
}

function calendari(widget, data) {

     var original = widget.getElementsByClassName('actiu')[0];

     if (typeof original === 'undefined') {
          original = document.createElement('table');
          original.setAttribute('data-actual',
              data.getFullYear() + '/' +
              data.getMonth().pad(2) + '/' +
              data.getDate().pad(2))
          widget.appendChild(original);
     }

     var diff = data - new Date(original.getAttribute('data-actual'));

     diff = new Date(diff).getMonth();

     var e = document.createElement('table');

     e.className = diff === 0 ? 'amagat-esquerra' : 'amagat-dreta';
     e.innerHTML = '';

     widget.appendChild(e);

     e.setAttribute('data-actual',
      data.getFullYear() + '/' +
      data.getMonth().pad(2) + '/' +
      data.getDate().pad(2))

     var fila = document.createElement('tr');
     var titol = document.createElement('th');
     titol.setAttribute('colspan', 7);
     titol.setAttribute('ng-model', 'dates.month')

     var boto_prev = document.createElement('button');
     boto_prev.className = 'boto-prev';
     boto_prev.innerHTML = '&#9666;';

     var boto_next = document.createElement('button');
     boto_next.className = 'boto-next';
     boto_next.innerHTML = '&#9656;';

     var Mes = document.createElement('span');
     Mes.className = 'Moth';
     titol.appendChild(boto_prev);
     titol.appendChild(Mes).innerHTML = mesos[data.getMonth()];
     var yearSpan = document.createElement('span');
     yearSpan.className = "any";
     yearSpan.textContent = data.getFullYear();

     titol.appendChild(yearSpan);

     titol.appendChild(boto_next);

     boto_prev.onclick = function () {
          data.setMonth(data.getMonth() - 1);
          calendari(widget, data);
     };

     boto_next.onclick = function () {
          data.setMonth(data.getMonth() + 1);
          calendari(widget, data);
     };

     fila.appendChild(titol);
     e.appendChild(fila);

     fila = document.createElement('tr');

     for (var i = 1; i < 7; i++) {
          fila.innerHTML += '<th>' + dies_abr[i] + '</th>';
     }

     fila.innerHTML += '<th>' + dies_abr[0] + '</th>';
     e.appendChild(fila);

     /* Obtinc el dia que va acabar el mes anterior */
     var inici_mes =
     new Date(data.getFullYear(), data.getMonth(), 0).getDay();

     var actual = new Date(data.getFullYear(),
         data.getMonth(),
         -inici_mes);

     for (var s = 0; s < 6; s++) {
          var fila = document.createElement('tr');

          for (var d = 1; d < 8; d++) {
               var cela = document.createElement('td');
               var link = document.createElement('a');
               var span = document.createElement('span');
               var borde = document.createElement('span');
               span.setAttribute('date', 'dates.day');
               link.className = 'Dia';
               borde.className = 'borde';
               cela.appendChild(link);
               link.appendChild(span);
               span.appendChild(borde);


               borde.innerHTML = actual.getDate();

               if (actual.getMonth() !== data.getMonth()) cela.className = 'fora';

               /* Si es avui el decorem */
               if (data.getDate() == actual.getDate() && data.getMonth() == actual.getMonth()) cela.className = 'avui';
               actual.setDate(actual.getDate() + 1);
               fila.appendChild(cela);
          }

          e.appendChild(fila);

     }

     setTimeout(function () {
          e.className = 'actiu';
          original.className +=
          diff === 0 ? ' amagat-dreta' : ' amagat-esquerra';
     }, 20);

     original.className = 'inactiu';

     setTimeout(function () {
          var inactius = document.getElementsByClassName('inactiu');
          for (var i = 0; i < inactius.length; i++)
               widget.removeChild(inactius[i]);
     }, 1000);

     eventos(data);

}

calendari(document.getElementById('calendari'), new Date());