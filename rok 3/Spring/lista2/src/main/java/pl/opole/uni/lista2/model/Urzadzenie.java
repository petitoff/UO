package pl.opole.uni.lista2.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;

import java.util.List;
import java.util.Objects;

@Entity
public class Urzadzenie {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer urzadzenieID;
    @ManyToOne
    @JoinColumn(name = "rodzaj")
    private RodzajUrzadzenia rodzajUrzadzenia;

    @ManyToOne
    @JoinColumn(name = "producent")
    private Producent producent;

    private String numerEwidencyjny;
    private String nazwa;
    @JsonIgnore
    @ManyToMany(mappedBy = "urzadzenia")
    private List<Uzytkownik> uzytkownicy;

    public Integer getUrzadzenieID() {
        return urzadzenieID;
    }

    public void setUrzadzenieID(Integer urzadzenieID) {
        this.urzadzenieID = urzadzenieID;
    }

    public RodzajUrzadzenia getRodzajUrzadzenia() {
        return rodzajUrzadzenia;
    }

    public void setRodzajUrzadzenia(RodzajUrzadzenia rodzajUrzadzenia) {
        this.rodzajUrzadzenia = rodzajUrzadzenia;
    }

    public Producent getProducent() {
        return producent;
    }

    public void setProducent(Producent producent) {
        this.producent = producent;
    }

    public String getNumerEwidencyjny() {
        return numerEwidencyjny;
    }

    public void setNumerEwidencyjny(String numerEwidencyjny) {
        this.numerEwidencyjny = numerEwidencyjny;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }

    public List<Uzytkownik> getUzytkownicy() {
        return uzytkownicy;
    }

    public void setUzytkownicy(List<Uzytkownik> uzytkownicy) {
        this.uzytkownicy = uzytkownicy;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Urzadzenie that = (Urzadzenie) o;
        return Objects.equals(urzadzenieID, that.urzadzenieID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(urzadzenieID);
    }
}
