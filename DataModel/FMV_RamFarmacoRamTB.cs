using DataModel.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DataModel
{
    public class FMV_RamFarmacoRamTB : SystemId
    {
        //RAM
        private long? farmacoId;
        public long? FarmacoId { get => farmacoId; set => SetProperty(ref farmacoId, value); }
        private FMV_RamFarmacoTB? farmaco;
        [Required(ErrorMessage = "requerido")]
        [JsonIgnore]
        public virtual FMV_RamFarmacoTB? Farmaco { get => farmaco; set => SetProperty(ref farmaco, value); }

        // RAM
        private string ram;
        [StringLength(250)]
        [Required(ErrorMessage = "requerido")]
        public string Ram { get => ram; set => SetProperty(ref ram, value); }

        // SOC: Los valores de la lista varia según las filas 
        private long? socId;
        public long? SocId { get => socId; set => SetProperty(ref socId, value); }
        // SOC: Los valores de la lista varia según las filas 
        private string soc;
        public string Soc { get => soc; set => SetProperty(ref soc, value); }

        // SOC: Los valores de la lista varia según las filas 
        private long? terMedraId;
        public long? TerMedraId { get => terMedraId; set => SetProperty(ref terMedraId, value); }
        // TERMINO WHOArt (LLT) -- Término MedDRA
        private string terWhoArt;
        public string TerWhoArt { get => terWhoArt; set => SetProperty(ref terWhoArt, value); }


        // Concomitantes
        private string concomitantes;
        public string Concomitantes { get => concomitantes; set => SetProperty(ref concomitantes, value); }

        // Fecha de RAM, null
        private DateTime? fechaRam;
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FechaRam { get => fechaRam; set => SetProperty(ref fechaRam, value); }

        // Desenlace. Total=7. Recuperado con secuelas, Recuperado sin secuelas, En recuperación, No recuperado, Desconocido, Muerte, null
        private enumFMV_RAMDesenlace desenlace;
        public enumFMV_RAMDesenlace Desenlace { get => desenlace; set => SetProperty(ref desenlace, value); }

        // Evolución sobre Dosis. Total=3. Desapareció la reacción al diminuir la dosis, Permanece la reacción al disminuir la dosis, null
        private enumFMV_RAMEvolucionDosis evoDosis;
        public enumFMV_RAMEvolucionDosis EvoDosis { get => evoDosis; set => SetProperty(ref evoDosis, value); }

        // Evolución sobre Terapia. Total=3. Desapareció la reacción al suspender el uso del medicamento sospechoso, Permanece la reacción al suspender el uso del medicamento sospechoso, null
        private enumFMV_RAMEvolucionTerapia evoTerapia;
        public enumFMV_RAMEvolucionTerapia EvoTerapia { get => evoTerapia; set => SetProperty(ref evoTerapia, value); }

        // Consecuencia de Reexposición. Total=3. Reapareció la reacción luego de reexposición, No reaparece la reacción luego de reexposición, null
        private enumFMV_RAMConsecuenciaReexposicion conReexposicion;
        public enumFMV_RAMConsecuenciaReexposicion ConReexposicion { get => conReexposicion; set => SetProperty(ref conReexposicion, value); }

        // RAM con una sola Dosis. Total=3. Si, No, null
        private enumOpcionSiNo ramUnaDosis;
        public enumOpcionSiNo RamUnaDosis { get => ramUnaDosis; set => SetProperty(ref ramUnaDosis, value); }



        // Secuencia Temporal. Total=6. Compatible, Compatible pero con coherente, No hay información, Incompatible, RAM aparecida por retirada del fármaco, null
        private enumFMV_RAMSecuenciaTemp secTemporal;
        public enumFMV_RAMSecuenciaTemp SecTemporal { get => secTemporal; set => SetProperty(ref secTemporal, value); }

        // STEMP. Total=6. 2, 1, 0, -1, -2, null
        /*
            FÓRMULA: Asignar valor a [stemp] según el valor de [secTemporal].
                     [secTemporal]="Compatible" entonces [stemp]=2,
                     [secTemporal]="Compatible pero no coherente" entonces [stemp]=1,
                     [secTemporal]="No hay información" entonces [stemp]=0,
                     [secTemporal]="Incompatible" entonces [stemp]=-1,
                     [secTemporal]="RAM aparecida por retirada del fármaco" entonces [stemp]=-2,
                     sino entonces [stemp]=""
        */
        private int stemp;
        public int Stemp { get => stemp; set => SetProperty(ref stemp, value); }

        // Conocimiento Previo. Total=5. RAM bien conocida, RAM conocida en referencias ocasionales, RAM desconocida, Existe información en contra de la relación fármaco-RAM, null
        private enumFMV_RAMConocimientoPrev conPrevio;
        public enumFMV_RAMConocimientoPrev ConPrevio { get => conPrevio; set => SetProperty(ref conPrevio, value); }

        // CPREV. Total=5. 2, 1, 0, -1, null
        /*
            FÓRMULA: Asignar valor a [cprev] según el valor de [conPrevio].
                     [conPrevio]="RAM bien conocida" entonces [cprev]=2,
                     [conPrevio]="RAM conocida en referencias ocasionales" entonces [cprev]=1,
                     [conPrevio]="RAM desconocida" entonces [cprev]=0,
                     [conPrevio]="Existe información en contra de la relación fármaco-RAM" entonces [cprev]=-1,
                     sino entonces [cprev]=null
        */
        private int cprev;
        public int Cprev { get => cprev; set => SetProperty(ref cprev, value); }

        // Efecto de Retirada. Total=9. RAM mejorada, RAM no mejorada, No RETI y RAM no mejora, No RETI y RAM mejora, No hay información, RAM mortal o irreversible, No RETI y RAM mejora por tolerancia, No RETI y RAM mejora por tratamiento, null
        private enumFMV_RAMEfectoRetirada efecRetirada;
        public enumFMV_RAMEfectoRetirada EfecRetirada { get => efecRetirada; set => SetProperty(ref efecRetirada, value); }

        // RETI. Total=5. 2, 1, 0, -2, null
        /*
            FÓRMULA: Asignar valor a [reti] según el valor de [efecRetirada].
                     [efecRetirada]="RAM mejora" entonces [reti]=2,
                     [efecRetirada]="RAM no mejora" entonces [reti]=-2,
                     [efecRetirada]="No RETI y RAM no mejora" entonces [reti]=1,
                     [efecRetirada]="No RETI y RAM mejora" entonces [reti]=-2,
                     [efecRetirada]="No hay información" entonces [reti]=0,
                     [efecRetirada]="RAM mortal o irreversible" entonces [reti]=0,
                     [efecRetirada]="No RETI y RAM mejora por tolerancia" entonces [reti]=1,
                     [efecRetirada]="No RETI y RAM mejora por tratamiento" entonces [reti]=1,
                     sino entonces [reti]=null
        */
        private int reti;
        public int Reti { get => reti; set => SetProperty(ref reti, value); }

        // Efecto de Reexposición. Total=7. Rexxposición positiva, Reexposición negativa, No hay reexposición o información suficiente, RAM mortal o irreversible, Reacción previa similar con otras especialidades farmacéuticas con el mismo principio activo, Reacción previa similar con otro fármaco con mismo mecanismo de acción o reactividad cruzada
        private enumFMV_RAMEfectoReexposicion efecReexposicion;
        public enumFMV_RAMEfectoReexposicion EfecReexposicion { get => efecReexposicion; set => SetProperty(ref efecReexposicion, value); }


        // REEX. Total=5. 3, 1, 0, -1, null
        /*
            FÓRMULA: Asignar valor a [reex] según el valor de [efecReexposicion].
                        [efecReexposicion]="Reexposición positiva" entonces [reex]=3,
                        [efecReexposicion]="Reexposición negativa" entonces [reex]=-1,
                        [efecReexposicion]="No hay reexposición o información suficiente" entonces [reex]=0,
                        [efecReexposicion]="RAM mortal o irreversible" entonces [reex]=0,
                        [efecReexposicion]="Reacción previa similar con otras especialidades farmacéuticas
                                            con el mismo principio activo" entonces [reex]=1,
                        [efecReexposicion]="Reacción previa similar con otro fármaco con mismo mecanismo
                                            de acción o reactividad cruzada" entonces [reex]=1,
                        sino entonces [reex]=null
        */
        private int reex;
        public int Reex { get => reex; set => SetProperty(ref reex, value); }


        // Causas Alternativas. Total=5. Explicación alternativa más verosímil, ALTER igual o menor, No hay información, Se descarta, null
        private enumFMV_RAMCausaAlternat causasAlter;
        public enumFMV_RAMCausaAlternat CausasAlter { get => causasAlter; set => SetProperty(ref causasAlter, value); }

        // ALTER. Total=5. 1, 0, -1, -3, null
        /*
            FÓRMULA: Asignar valor a [alter] según el valor de [causasAlter].
                     [causasAlter]="Explicación alternativa más verosímil" entonces [alter]=-3,
                     [causasAlter]="ALTER igual o menor" entonces [alter]=-1,
                     [causasAlter]="No hay información " entonces [alter]=0,
                     [causasAlter]="Se descarta" entonces [alter]=1,
                     sino entonces [alter]=null
        */
        private int alter;
        public int Alter { get => alter; set => SetProperty(ref alter, value); }

        // Factores Contribuyentes. Total=3. Factores que pueden haber contribuido a la presentación de la RAM, No hay factores contribuyentes, null
        private enumFMV_RAMFactContribuyente factContribuyentes;
        public enumFMV_RAMFactContribuyente FactContribuyentes { get => factContribuyentes; set => SetProperty(ref factContribuyentes, value); }

        // FACON. Total=3. 1, 0, null
        /*
            FÓRMULA: Asignar valor a [facon] según el valor de [factContribuyentes].
                     [factContribuyentes]="Factores que pueden haber contribuido a la presentación de la RAM" entonces [facon]=1
                     [factContribuyentes]="No hay factores contribuyentes" entonces [facon]=0
                     sino entonces [facon]=null
        */
        private int facon;
        public int Facon { get => facon; set => SetProperty(ref facon, value); }


        // Exploraciones Complementarias. Total=3. Existen exploraciones complementarias, No hay exploraciones complementarias, null
        private enumFMV_RAMExploracionContemp expComplementarias;
        public enumFMV_RAMExploracionContemp ExpComplementarias { get => expComplementarias; set => SetProperty(ref expComplementarias, value); }

        // XPLC
        /*
            FÓRMULA: Asignar valor a [xplc] según el valor de [expComplementarias].
                     [expComplementarias]="Existen exploraciones complementarias" entonces [xplc]=1
                     [expComplementarias]="No hay exploraciones complementarias" entonces [xplc]=0
                     sino entonces [xplc]=null
        */
        private int xplc;
        public int Xplc { get => xplc; set => SetProperty(ref xplc, value); }

        // Puntuación
        /*
            FÓRMULA: Si [stemp]="", [cprev]="", [reti]="", [reex]="", [alter]="", [facon]="" y [xplc]="" entonces [puntuacion]=""
                     sino entonces [puntuacion]=[stemp]+[cprev]+[reti]+[reex]+[alter]+[facon]+[xplc]
        */
        //private int puntuacion;
        //public int Puntuacion { get => puntuacion; set => SetProperty(ref puntuacion, value); }

        public int Puntuacion
        {
            get { return (stemp + cprev + reti + reex + alter + facon + xplc); }
        }

        // Probabilidad
        /*
            FÓRMULA: Si [xplc]="" entonces [probabilidad]=""
                     sino: Si [xplc]<=0 entonces [probabilidad]="Improbable"
                           sino: Si [xplc]>0 y [xplc]<4 entonces [probabilidad]="Condicional"
                                 sino: Si [xplc]>=4 y [xplc]<6 entonces [probabilidad]="Posible"
                                       sino: Si [xplc]>=6 y [xplc]<8 entonces [probabilidad]="Probable"
                                             sino: Si [xplc]>=8 entonces [probabilidad]="Definida"
                                                   sino entonces [probabilidad]="ERROR"
        */
        //private string probabilidad;
        //public string Probabilidad { get => probabilidad; set => SetProperty(ref probabilidad, value); }

        public string Probabilidad
        {
            get
            {
                return Puntuacion switch
                {
                    <= 0 => "Improbable",
                    > 0 and < 4 => "Condicional",
                    >= 4 and < 6 => "Posible",
                    >= 6 and < 8 => "Probable",
                    >= 8 => "Definida",
                };

            }
        }


        // Intensidad de la RAM. Total=9. Ocasiona la muerte, Pueda poner en peligro la vida, Requiere o prolonga una hospitalización, Produce una anomalía congénita o defecto al nacer
        //                                Provoca una incapacidad persistente significativa, Enfermedad o síndrome médicamente significativo o importante, Interfiere con las actividades habituales. Requieren intervención o tratamiento médico, Fácilmente tolerado. No requieren terapia ni intervención médica, null.
        private enumFMV_RAMIntensidad intRam;
        public enumFMV_RAMIntensidad IntRam { get => intRam; set => SetProperty(ref intRam, value); }

        // Gravedad. Total=4. Grave, Leve, Moderada, null.
        /*
            FÓRMULA: Asignar valor a [gravedad] según el valor de [intRam].
                     [intRam]="Ocasiona la  muerte" entonces [gravedad]="Grave",
                     [intRam]="Pueda poner en peligro la vida" entonces [gravedad]="Grave",
                     [intRam]="Requiere o prolonga una hospitalización" entonces [gravedad]="Grave",
                     [intRam]="Produce una anomalía congénita o defecto al nacer" entonces [gravedad]="Grave",
                     [intRam]="Provoca una incapacidad persistente significativa" entonces [gravedad]="Grave",
                     [intRam]="Enfermedad o síndrome médicamente significativo o importante" entonces [gravedad]="Grave",
                     [intRam]="Interfiere con las actividades habituales. Requieren intervención o tratamiento médico" entonces [gravedad]="Moderada",
                     [intRam]="Fácilmente tolerado. No requieren terapia ni intervención médica." entonces [gravedad]="Leve",
                     sino entonces [gravedad]=null
        */
        private string gravedad;
        public string Gravedad { get => gravedad; set => SetProperty(ref gravedad, value); }

        // Referencia
        private string referencia;
        public string Referencia { get => referencia; set => SetProperty(ref referencia, value); }


    }
}
