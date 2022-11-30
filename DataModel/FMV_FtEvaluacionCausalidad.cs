using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_FtEvaluacionCausalidad:SystemId
    {

        // ¿Fármaco con cinética compleja?. Total=3. Si, No, No sabe
        private enumOpcionSiNo farmCinCompleja;
        public enumOpcionSiNo FarmCinCompleja { get => farmCinCompleja; set => SetProperty(ref farmCinCompleja, value); }

        // ¿Condiciones clínicas que alteran la farmacocinética?. Total=3. Si, No, No sabe
        private enumOpcionSiNo condClinicas;
        public enumOpcionSiNo CondClinicas { get => condClinicas; set => SetProperty(ref condClinicas, value); }

        // ¿El medicamento se preescribió de manera inadecuada?. Total=3. Si, No, No sabe
        private enumOpcionSiNo preescritoInad;
        public enumOpcionSiNo Preescrito { get => preescritoInad; set => SetProperty(ref preescritoInad, value); }

        // ¿El medicamento se usó de manera inadecuada?. Total=3. Si, No, No sabe
        private enumOpcionSiNo usoInad;
        public enumOpcionSiNo UsoInad { get => usoInad; set => SetProperty(ref usoInad, value); }

        // ¿Tiene un método específico de administración que requiere entrenamiento en el paciente?. Total=3. Si, No, No sabe
        private enumOpcionSiNo entrenamientoPaciente;
        public enumOpcionSiNo EntrenamientoPaciente { get => entrenamientoPaciente; set => SetProperty(ref entrenamientoPaciente, value); }

        // ¿Existen potenciales interacciones?. Total=3. Si, No, No sabe
        private enumOpcionSiNo potInteracciones;
        public enumOpcionSiNo PotInteracciones { get => potInteracciones; set => SetProperty(ref potInteracciones, value); }

        // ¿La notificación de FT se refiere explícitamente al uso de un medicamento genérico o una marca comercial específica?. Total=3. Si, No, No sabe
        private enumOpcionSiNo notificacionFT;
        public enumOpcionSiNo NotificacionFT { get => notificacionFT; set => SetProperty(ref notificacionFT, value); }

        // ¿Existe algún problema biofarmacéutico estudiado?. Total=3. Si, No, No sabe
        private enumOpcionSiNo proBiofarmaceutico;
        public enumOpcionSiNo ProBiofarmaceutico { get => proBiofarmaceutico; set => SetProperty(ref proBiofarmaceutico, value); }

        // ¿Existen deficiencias en los sistemas de almacenamiento del medicamento?. Total=3. Si, No, No sabe
        private enumOpcionSiNo deficiencias;
        public enumOpcionSiNo Deficiencias { get => deficiencias; set => SetProperty(ref deficiencias, value); }

        // ¿Existen otros factores asociados que pudiera explicar el FT?. Total=3. Si, No, No sabe
        private enumOpcionSiNo factAsociados;
        public enumOpcionSiNo FactAsociados { get => factAsociados; set => SetProperty(ref factAsociados, value); }

        /*
         / COLUMNAS AZ - BD
        // AZ 1
        /*
           FÓRMULA: Si [farmCinCompleja]="", [condClinicas]="", [preescritoInad]="", [usoInad]="", [entrenamientoPaciente]="" y [potInteracciones]="" entonces az1=""
                    sino: Si [farmCinCompleja]="Si", [condClinicas]="Si", [preescritoInad]="Si", [usoInad]="Si", [entrenamientoPaciente]="Si" y [potInteracciones]="Si" entonces az1=1
                          sino: az1=""
        */

        // BA 2
        /*
           FÓRMULA: Si [farmCinCompleja]="", [condClinicas]="", [preescritoInad]="", [usoInad]="", [entrenamientoPaciente]="", [potInteracciones]="" y [notificacionFT]="" entonces ba2=""
                    sino: Si [farmCinCompleja]!="Si", [condClinicas]!="Si", [preescritoInad]!="Si", [usoInad]!="Si", [entrenamientoPaciente]!="Si", [potInteracciones]!="Si" y [notificacionFT]="Si" entonces ba2=2
                          sino: ba2=""
        */

        // BB 3
        /*
           FÓRMULA: Si [farmCinCompleja]="", [condClinicas]="", [preescritoInad]="", [usoInad]="", [entrenamientoPaciente]="", [potInteracciones]="", [notificacionFT]="", [proBiofarmaceutico]="" y [deficiencias]="" entonces bb3=""
                    sino: Si [farmCinCompleja]="No", [condClinicas]="No", [preescritoInad]="No", [usoInad]="No", [entrenamientoPaciente]="No" y [potInteracciones]="No" entonces
                             Si [proBiofarmaceutico]="Si" y [deficiencias]="Si" entonces bb3=3
                             sino: bb3=""
        */

        // BC 4
        /*
           FÓRMULA: Si [farmCinCompleja]="", [condClinicas]="", [preescritoInad]="", [usoInad]="", [entrenamientoPaciente]="", [potInteracciones]="", [notificacionFT]="", [proBiofarmaceutico]="", [deficiencias]="" y [factAsociados]="" entonces bc4=""
                    sino: Si [farmCinCompleja]="No", [condClinicas]="No", [preescritoInad]="No", [usoInad]="No", [entrenamientoPaciente]="No", [potInteracciones]="No", [notificacionFT]="No", [proBiofarmaceutico]="No", [deficiencias]="No" y [factAsociados]="Si" entonces bc4=4
                          sino: bc4=""
        */

        // BD 5
        /*
           FÓRMULA: Si [farmCinCompleja]="", [condClinicas]="", [preescritoInad]="", [usoInad]="", [entrenamientoPaciente]="", [potInteracciones]="", [notificacionFT]="", [proBiofarmaceutico]="", [deficiencias]="" y [factAsociados]="" entonces bd5=""
                    sino: Si [farmCinCompleja]!="Si", [condClinicas]!="Si", [preescritoInad]!="Si", [usoInad]!="Si", [entrenamientoPaciente]!="Si", [potInteracciones]!="Si", [notificacionFT]!="Si", [proBiofarmaceutico]!="Si", [deficiencias]!="Si" y [factAsociados]!="Si" entonces bd5=5
                          sino: bd5=""
        */


        // Categoría de Causalidad
        /*
            FÓRMULA: Si [az1]=1, [ba2]!=2, [bb3]!=3, [bc4]!=4 y [bd5]!=5 entonces catCausalidad="Posiblemente asociado al uso inadecuado del medicamento"
                     sino: Si  [az1]!=1, [ba2]=2, [bb3]!=3, [bc4]!=4 y [bd5]!=5 entonces catCausalidad="Notificación posiblemente inducida"
                           sino: Si [az1]!=1, [ba2]!=2, [bb3]=3, [bc4]!=4 y [bd5]!=5 entonces catCausalidad="Posiblemente asociado a un problema biofarmacéutico (calidad)"
                                 sino: Si [az1]!=1, [ba2]!=2, [bb3]!=3, [bc4]=4 y [bd5]!=5 entonces catCausalidad="Posiblemente asociado a respuesta idiosincrática u otras razones no establecidas que pudieran explicar el FT"
                                       sino: Si [az1]!=1, [ba2]!=2, [bb3]!=3, [bc4]!=4 y [bd5]=5 entonces catCausalidad="No se cuenta con información suficiente para el análisis"
                                             sino: catCausalidad="No Clasificable"
        */
        private string catCausalidad;
        public string CatCausalidad { get => catCausalidad; set => SetProperty(ref catCausalidad, value); }
    }
}
