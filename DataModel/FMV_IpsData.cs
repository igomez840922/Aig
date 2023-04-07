﻿using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_IpsData:SystemId
    {
        public FMV_IpsData() {
            SolInfoFabricante = enumFMV_IpsTipoPresentaiones.Yes;
        }    

        // Presenta CD: CD/USB, Impreso, No adjunta
        private enumFMV_IpsPresentaCD presentaCd;
        public enumFMV_IpsPresentaCD PresentaCd { get => presentaCd; set => SetProperty(ref presentaCd, value); }

        // Periodo que cubre
        //periodo inicial
        private DateTime? periodoIni;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PeriodoIni { get => periodoIni; set => SetProperty(ref periodoIni, value); }
        //periodo final
        private DateTime? periodoFin;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? PeriodoFin { get => periodoFin; set => SetProperty(ref periodoFin, value); }

        // Fecha de Registro
        private DateTime? fechaRegistro;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRegistro { get => fechaRegistro; set => SetProperty(ref fechaRegistro, value); }

        // Fecha asignacion pre evaluacion
        private DateTime? fechaAsigPreEva;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaAsigPreEva { get => fechaAsigPreEva; set => SetProperty(ref fechaAsigPreEva, value); }


        //// Innovador: si, no
        //private bool innovador;
        //public bool Innovador { get => innovador; set => SetProperty(ref innovador, value); }

        ////Biologico: si, no
        //private bool biologico;
        //public bool Biologico { get => biologico; set => SetProperty(ref biologico, value); }

        //// Requiere intercambiabilidad: si, no
        //private bool reqIntercam;
        //public bool ReqIntercam { get => reqIntercam; set => SetProperty(ref reqIntercam, value); }

        // Fecha de autorizacion en Panamá
        private DateTime? fechaAutPan;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaAutPan { get => fechaAutPan; set => SetProperty(ref fechaAutPan, value); }

        // Fecha de pre evaluacion
        private DateTime? fechaPreEva;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaPreEva { get => fechaPreEva; set => SetProperty(ref fechaPreEva, value); }

        // Tabla de contenido: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones tablaContenido;
        public enumFMV_IpsTipoPresentaiones TablaContenido { get => tablaContenido; set { SetProperty(ref tablaContenido, value); UpdateRule(); } }

        // Introducción: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones introduccion;
        public enumFMV_IpsTipoPresentaiones Introduccion { get => introduccion; set { SetProperty(ref introduccion, value); UpdateRule(); } }

        // Situacion mundial de autorizacion de comercializacion: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones sitMunAutCom;
        public enumFMV_IpsTipoPresentaiones SitMunAutCom { get => sitMunAutCom; set { SetProperty(ref sitMunAutCom, value); UpdateRule(); } }

        // Medidas adoptadas por ARNs o TRS: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones medAdoptada;
        public enumFMV_IpsTipoPresentaiones MedAdoptada { get => medAdoptada; set { SetProperty(ref medAdoptada, value); UpdateRule(); } }

        // Cambios a la informacion de seguridad: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones camInfoSeg;
        public enumFMV_IpsTipoPresentaiones CamInfoSeg { get => camInfoSeg; set { SetProperty(ref camInfoSeg, value); UpdateRule(); } }

        // Monografía: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones monografia;
        public enumFMV_IpsTipoPresentaiones Monografia { get => monografia; set { SetProperty(ref monografia, value); UpdateRule(); } }

        // Exposicion estimada y patrones de uso: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones expEstimada;
        public enumFMV_IpsTipoPresentaiones ExpEstimada { get => expEstimada; set { SetProperty(ref expEstimada, value); UpdateRule(); } }

        // Presentacion de casos (RAMs reportadas): Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones presCasos;
        public enumFMV_IpsTipoPresentaiones PresCasos { get => presCasos; set { SetProperty(ref presCasos, value); UpdateRule(); } }

        // Resumen de hallazgos significantes de seguridad: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones resHallazgo;
        public enumFMV_IpsTipoPresentaiones ResHallazgo { get => resHallazgo; set { SetProperty(ref resHallazgo, value); UpdateRule(); } }

        // Otra información relacionada: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones otraInfRel;
        public enumFMV_IpsTipoPresentaiones OtraInfRel { get => otraInfRel; set { SetProperty(ref otraInfRel, value); UpdateRule(); } }

        // Datos no clínicos: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones datosNoCli;
        public enumFMV_IpsTipoPresentaiones DatosNoCli { get => datosNoCli; set { SetProperty(ref datosNoCli, value); UpdateRule(); } }

        // Otros informes periodicos: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones otroInfPer;
        public enumFMV_IpsTipoPresentaiones OtroInfPer { get => otroInfPer; set { SetProperty(ref otroInfPer, value); UpdateRule(); } }

        // Falta de eficacia en ensayos clínicos controlados: No hay estudios, no presentado, si, no
        private enumFMV_IpsTipoPresentaiones2 faltaEficacia;
        public enumFMV_IpsTipoPresentaiones2 FaltaEficacia { get => faltaEficacia; set { SetProperty(ref faltaEficacia, value); UpdateRule(); } }

        // Revision de señales: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones revisionSenales;
        public enumFMV_IpsTipoPresentaiones RevisionSenales { get => revisionSenales; set { SetProperty(ref revisionSenales, value); UpdateRule(); } }

        // Evaluación de señales y riesgos: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones evaluacionSenales;
        public enumFMV_IpsTipoPresentaiones EvaluacionSenales { get => evaluacionSenales; set { SetProperty(ref evaluacionSenales, value); UpdateRule(); } }

        // Evaluación del beneficio: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones evaluacionBeneficio;
        public enumFMV_IpsTipoPresentaiones EvaluacionBeneficio { get => evaluacionBeneficio; set { SetProperty(ref evaluacionBeneficio, value); UpdateRule(); } }

        // Análisis de beneficio riesgo: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones anaBenRiesgo;
        public enumFMV_IpsTipoPresentaiones AnaBenRiesgo { get => anaBenRiesgo; set { SetProperty(ref anaBenRiesgo, value); UpdateRule(); } }

        // Conclusiones y acciones: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones concluAcciones;
        public enumFMV_IpsTipoPresentaiones ConcluAcciones { get => concluAcciones; set { SetProperty(ref concluAcciones, value); UpdateRule(); } }

        // Anexos y apendices: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones anexoApendice;
        public enumFMV_IpsTipoPresentaiones AnexoApendice { get => anexoApendice; set { SetProperty(ref anexoApendice, value); UpdateRule(); } }

        // Ha cambiado el balance B/R: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones cambioBalance;
        public enumFMV_IpsTipoPresentaiones CambioBalance { get => cambioBalance; set { SetProperty(ref cambioBalance, value); UpdateRule(); } }

        // Hay propuestas de un plan de accion: Presentado, No Presentado, Si, No
        private enumFMV_IpsTipoPresentaiones propPlanAccion;
        public enumFMV_IpsTipoPresentaiones PropPlanAccion { get => propPlanAccion; set { SetProperty(ref propPlanAccion, value); UpdateRule(); } }

        // Solicitud de informacion al fabricante: Si, no
        private enumFMV_IpsTipoPresentaiones solInfoFabricante;
        public enumFMV_IpsTipoPresentaiones SolInfoFabricante { get => solInfoFabricante; set => SetProperty(ref solInfoFabricante, value); }

        // Observaciones
        private string observaciones;
        public string Observaciones { get => observaciones; set => SetProperty(ref observaciones, value); }

        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        List<enumFMV_IpsTipoPresentaiones> lTipoPresentaiones = new List<enumFMV_IpsTipoPresentaiones>();
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        List<enumFMV_IpsTipoPresentaiones> lTipoPresentaiones2 = new List<enumFMV_IpsTipoPresentaiones>();
        [System.ComponentModel.DataAnnotations.Schema.NotMapped]
        List<enumFMV_IpsTipoPresentaiones> lTipoPresentaionesExternal = new List<enumFMV_IpsTipoPresentaiones>();

        public void UpdateRule() {
            
            CheckList();
            var pp = lTipoPresentaiones.All(x => x != enumFMV_IpsTipoPresentaiones.NotPresent);
             pp = FaltaEficacia != enumFMV_IpsTipoPresentaiones2.NotPresent;
             pp = (lTipoPresentaionesExternal?.All(x => x != enumFMV_IpsTipoPresentaiones.NotPresent) ?? true);
            SolInfoFabricante = lTipoPresentaiones.All(x => x != enumFMV_IpsTipoPresentaiones.NotPresent) && FaltaEficacia != enumFMV_IpsTipoPresentaiones2.NotPresent && (lTipoPresentaionesExternal?.All(x => x != enumFMV_IpsTipoPresentaiones.NotPresent) ??true) ? enumFMV_IpsTipoPresentaiones.No : enumFMV_IpsTipoPresentaiones.Yes;
            if(SolInfoFabricante == enumFMV_IpsTipoPresentaiones.Yes) {
                return;
            }

            pp = lTipoPresentaiones2.All(x => x == enumFMV_IpsTipoPresentaiones.No);
            pp = FaltaEficacia == enumFMV_IpsTipoPresentaiones2.No;
            SolInfoFabricante = lTipoPresentaiones2.All(x => x == enumFMV_IpsTipoPresentaiones.No) && FaltaEficacia == enumFMV_IpsTipoPresentaiones2.No ? enumFMV_IpsTipoPresentaiones.No : enumFMV_IpsTipoPresentaiones.Yes;

        }
        
        void CheckList() {
            if(lTipoPresentaiones?.Count > 0 && lTipoPresentaiones2?.Count > 0) { lTipoPresentaiones.Clear(); }
            lTipoPresentaiones = new List<enumFMV_IpsTipoPresentaiones>()
              { TablaContenido, Introduccion, SitMunAutCom, MedAdoptada, CamInfoSeg,Monografia,ExpEstimada,PresCasos,ResHallazgo,
            OtraInfRel,DatosNoCli,OtroInfPer,RevisionSenales,EvaluacionSenales,EvaluacionBeneficio,AnaBenRiesgo,ConcluAcciones,
            AnexoApendice,CambioBalance,PropPlanAccion};
            if (lTipoPresentaiones2?.Count > 0 && lTipoPresentaiones2?.Count > 0) { lTipoPresentaiones2.Clear(); }
            lTipoPresentaiones2 = new List<enumFMV_IpsTipoPresentaiones>()
            {MedAdoptada,CamInfoSeg,ResHallazgo,CambioBalance,PropPlanAccion};
        }
        public void ExternalUpdateRule(enumFMV_IpsTipoPresentaiones TipoPresentaiones1 = enumFMV_IpsTipoPresentaiones.NotPresent, enumFMV_IpsTipoPresentaiones TipoPresentaiones2 = enumFMV_IpsTipoPresentaiones.NotPresent) {
            if (lTipoPresentaionesExternal?.Count > 0 && lTipoPresentaionesExternal?.Count > 0) { lTipoPresentaionesExternal.Clear(); }
            lTipoPresentaionesExternal = new List<enumFMV_IpsTipoPresentaiones> { TipoPresentaiones1, TipoPresentaiones2 };
            UpdateRule();
        }

    }
}
