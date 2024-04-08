package pl.opole.uni.lista2.model;

import com.fasterxml.jackson.annotation.JsonIgnore;
import jakarta.persistence.*;

import java.util.List;
import java.util.Objects;

@Entity
public class Producent {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Integer producentID;
    private String symbol;
    private String nazwa;
    @JsonIgnore
    @OneToMany(mappedBy = "producent")
    private List<Urzadzenie> urzadzenia;

    public Integer getProducentID() {
        return producentID;
    }

    public void setProducentID(Integer producentID) {
        this.producentID = producentID;
    }

    public String getSymbol() {
        return symbol;
    }

    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }

    public String getNazwa() {
        return nazwa;
    }

    public void setNazwa(String nazwa) {
        this.nazwa = nazwa;
    }

    public List<Urzadzenie> getUrzadzenia() {
        return urzadzenia;
    }

    public void setUrzadzenia(List<Urzadzenie> urzadzeniea) {
        this.urzadzenia = urzadzeniea;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;
        Producent producent = (Producent) o;
        return Objects.equals(producentID, producent.producentID);
    }

    @Override
    public int hashCode() {
        return Objects.hash(producentID);
    }
}
